#include "HID-Project.h"    //https://github.com/NicoHood/HID
#include <MPU6050_tockn.h>  //https://github.com/tockn/MPU6050_tockn
#include <Wire.h>
#include <EEPROM.h>

// EEPROM Offsets for config and calibration stuff
#define EE_VERSION 0
// these are floats (4 bytes)
#define EE_PITCH_SENSITIVITY 1
#define EE_YAW_SENSITIVITY 5
#define EE_ROLL_SENSITIVITY 9
#define EE_PITCH_EXPONENTIAL 13
#define EE_YAW_EXPONENTIAL 17
#define EE_ROLL_EXPONENTIAL 21
#define EE_PITCH_OFFSET 25
#define EE_YAW_OFFSET 29
#define EE_ROLL_OFFSET 33
#define EE_PITCH_ANGLE_LIMIT 37
#define EE_YAW_ANGLE_LIMIT 41
#define EE_ROLL_ANGLE_LIMIT 45
// 1 byte
#define EE_USE_EXPONENTIAL_MODE 49
#define EE_USE_SMOOTHNESS 50
#define EE_IS_ON 51

#define MAX_VALUE 32000
#define MAX_MESSAGE_LENGTH 48
#define AVERAGE_BUFFER_SIZE 40 

float rawPitch = 0; 
float rawYaw = 0;
float rawRoll = 0;

float pitch = 0; 
float yaw = 0;
float roll = 0;

float offsetPitch = 0;
float offsetYaw = 0;
float offsetRoll = 0;

int gamepadPitch = 0;
int gamepadYaw = 0;
int gamepadRoll = 0;

MPU6050 mpu6050(Wire);

//variables that will be loaded form EEPROM
byte _version = 0;

float pitchSensitivity = 0;
float yawSensitivity = 0;
float rollSensitivity = 0;

float pitchExponential = 0;
float yawExponential = 0;
float rollExponential = 0;

float gyroPitchOffset = 0;
float gyroYawOffset = 0;
float gyroRollOffset = 0;

float pitchLimit = 0;
float yawLimit = 0;
float rollLimit = 0;

bool useExponentialMode = false;
bool useSmoothness = false;
bool isOn = false;

long timer = 0;

byte averageBufferIndex = 0;
float averageBufferPitch[AVERAGE_BUFFER_SIZE];
float averageBufferYaw[AVERAGE_BUFFER_SIZE];
float averageBufferRoll[AVERAGE_BUFFER_SIZE];

void setup() {

  delay(1000);

  Serial.begin(9600);
  while (!Serial); // wait for Leonardo enumeration, others continue immediately
  Serial.flush();
  
  EEPROM.get(EE_VERSION, _version);

  EEPROM.get(EE_PITCH_SENSITIVITY, pitchSensitivity);
  EEPROM.get(EE_YAW_SENSITIVITY, yawSensitivity);
  EEPROM.get(EE_ROLL_SENSITIVITY, rollSensitivity);

  EEPROM.get(EE_PITCH_EXPONENTIAL, pitchExponential);
  EEPROM.get(EE_YAW_EXPONENTIAL, yawExponential);
  EEPROM.get(EE_ROLL_EXPONENTIAL, rollExponential);

  EEPROM.get(EE_PITCH_OFFSET, gyroPitchOffset);
  EEPROM.get(EE_YAW_OFFSET, gyroYawOffset);
  EEPROM.get(EE_ROLL_OFFSET, gyroRollOffset);

  EEPROM.get(EE_PITCH_ANGLE_LIMIT, pitchLimit);
  EEPROM.get(EE_YAW_ANGLE_LIMIT, yawLimit);
  EEPROM.get(EE_ROLL_ANGLE_LIMIT, rollLimit);

  EEPROM.get(EE_USE_EXPONENTIAL_MODE, useExponentialMode);
  EEPROM.get(EE_USE_SMOOTHNESS, useSmoothness);
  EEPROM.get(EE_IS_ON, isOn);


  Gamepad.begin();

  Wire.begin();
  mpu6050.begin();
  //mpu6050.calcGyroOffsets(true); //This is is not a necessary call. works fine without it.
  mpu6050.setGyroOffsets(gyroPitchOffset, gyroYawOffset, gyroRollOffset);

}

void loop() 
{  

  if(Serial.available()){
      reciveMessage();
  }

  if(isOn){
    updatePRY();

    Gamepad.yAxis(gamepadPitch);
    Gamepad.xAxis(gamepadYaw);
    Gamepad.zAxis(gamepadRoll);
    Gamepad.write();

  }

}

void updatePRY(){
  mpu6050.update();
  rawPitch = mpu6050.getAngleX();
  rawRoll = mpu6050.getAngleY();
  rawYaw = mpu6050.getAngleZ();
  
  // Apply offsets
  rawPitch -= offsetPitch;
  rawRoll -= offsetRoll;
  rawYaw -= offsetYaw;
  
  pitch = rawPitch;
  roll = rawRoll;
  yaw = rawYaw;

  /*if(millis() - timer > 1000){
    Serial.println("---");
    Serial.print(pitch); Serial.print(" "); Serial.print(yaw); Serial.print(" "); Serial.println(roll);
  }*/
  
  // Apply angel limits
  pitch = constrain(pitch, -pitchLimit, pitchLimit);
  yaw = constrain(yaw, -yawLimit, yawLimit);
  roll = constrain(roll, -rollLimit, rollLimit);

  
  if (useExponentialMode) {//somewhere around 0.001422076 is good
    pitch = (pitchExponential / 10000 * pitch * pitch * pitchSensitivity) * (pitch / abs(pitch));
    roll = (rollExponential / 10000 * roll * roll * rollSensitivity) * (roll / abs(roll));
    yaw = (yawExponential / 10000 * yaw * yaw * yawSensitivity) * (yaw / abs(yaw));
  }
  else
  {
    pitch = (pitch * pitchSensitivity);
    roll = (roll * rollSensitivity);
    yaw = (yaw * yawSensitivity);
  }

  /*if(millis() - timer > 1000){
    Serial.print("\t\t\t"); Serial.print(pitch); Serial.print(" "); Serial.print(yaw); Serial.print(" "); Serial.println(roll);
  }*/

  pitch = constrain(pitch, -MAX_VALUE, MAX_VALUE);
  yaw = constrain(yaw, -MAX_VALUE, MAX_VALUE);
  roll = constrain(roll, -127, 127);


  if(useSmoothness){

    //rotates thought the buffer and updates the oldes value
    averageBufferPitch[averageBufferIndex] = pitch;
    averageBufferYaw[averageBufferIndex] = yaw;
    averageBufferRoll[averageBufferIndex] = roll;
    
    averageBufferIndex = (averageBufferIndex + 1) % AVERAGE_BUFFER_SIZE;

    gamepadPitch = getAverage(averageBufferPitch);
    gamepadYaw = getAverage(averageBufferYaw);
    gamepadRoll = getAverage(averageBufferRoll);

    /*if(millis() - timer > 1000){
      Serial.print("\t\t\t\t\t\t\t\t"); Serial.print(pitch); Serial.print(" "); Serial.print(yaw); Serial.print(" "); Serial.println(roll);
    }*/
    
  }else{
    gamepadPitch = pitch;
    gamepadYaw = yaw;
    gamepadRoll = roll;

    /*if(millis() - timer > 1000){
      Serial.print("\t\t\t\t\t\t\t\t\t\t\t"); Serial.print(gamepadPitch); Serial.print(" "); Serial.print(gamepadYaw); Serial.print(" "); Serial.println(gamepadRoll);
    }*/
  }
  

}

// ----- Protocol -----
//<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
//<1> //reset view
//<2 sensX sensY sensZ checksum>
//<3 expX expY expZ checksum>
//<4 offsetX offsetY offsetZ checksum>
//<5 limitX limitY limitZ checksum>
//<6 bool> //Toggle Smoothness
//<7> //run calibrateGyro
//<8 bool> //Turn on/off
//<9 bool> //Use Exponential

void reciveMessage(){
  delay(20);

  while(Serial.available() > 0){
    if((char) Serial.read() == '<'){
      
      char action = (char)Serial.read();
   
      //<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
      if(action == '0'){
        if((char)Serial.read() == '>'){
          printInfo(); 
        }else{
          Serial.println("ERROR: Expected '>'");
        }
      }
      
      //<1> //reset view
      if(action == '1'){
        if((char)Serial.read() == '>'){
          zeroMPU6050();
        }else{
          Serial.println("ERROR: Expected '>'");
        }
      }

      //<2 sensX sensY sensZ checksum>
      if(action == '2'){
        float floats[3];
        if (get3FloatsFromMsg(floats)){
          Serial.print(floats[0]); Serial.print(" "); Serial.print(floats[1]); Serial.print(" "); Serial.println(floats[2]);
          setSensitivity(floats[0], floats[1], floats[2]);
        }
      }

      //<3 expX expY expZ checksum>
      if(action == '3'){
        float floats[3];
        if (get3FloatsFromMsg(floats)){
          Serial.print(floats[0]); Serial.print(" "); Serial.print(floats[1]); Serial.print(" "); Serial.println(floats[2]);
          setExponential(floats[0], floats[1], floats[2]);
        }
      }

      //<4 offsetX offsetY offsetZ checksum>
      if(action == '4'){
        float floats[3];
        if (get3FloatsFromMsg(floats)){
          Serial.print(floats[0]); Serial.print(" "); Serial.print(floats[1]); Serial.print(" "); Serial.println(floats[2]);
          setOffset(floats[0], floats[1], floats[2]);
        }
      }

      //<5 limitX limitY limitZ checksum>
      if(action == '5'){
        float floats[3];
        if (get3FloatsFromMsg(floats)){
          Serial.print(floats[0]); Serial.print(" "); Serial.print(floats[1]); Serial.print(" "); Serial.println(floats[2]);
          setLimit(floats[0], floats[1], floats[2]);
        }
      }

      //<6 bool> //Toggle Smoothness
      if(action == '6'){
        bool b = false;
        if(getBoolFromMsg(b)){
          setSmoothness(b);
        }
      }

      //<7> //run calibrateGyro
      if(action == '7'){
        if((char)Serial.read() == '>'){
          mpu6050.calcGyroOffsets(true);
          Serial.println("Gyro is Running!");
        }else{
          Serial.println("ERROR: Expected '>'");
        }
      }
      
      //<8 bool> //Turn on/off
      if(action == '8'){
        bool b = false;
        if(getBoolFromMsg(b)){
          setIsOn(b);
        }
      }

      //<9 bool> //Use Exponential
      if(action == '9'){
        bool b = false;
        if(getBoolFromMsg(b)){
          setExponentialMode(b);
        }
      }
    }
  }
}


//Calculates the average of the given array
float getAverage(float (&averageBuffer) [AVERAGE_BUFFER_SIZE]){
  float average = 0;
  for(int i = 0; i < AVERAGE_BUFFER_SIZE; i++){
    average += averageBuffer[i];
  }
  
  return average / AVERAGE_BUFFER_SIZE;
}



bool getBoolFromMsg(bool &result){
  char b = (char)Serial.read();
  if((char)Serial.read() == '>'){
    if(b == '0'){
      result = false;
    }else if(b == '1'){
      result = true;
    }else{
      Serial.println("ERROR: Data is not a Bool!");
      return false;
    }
  }else{
    Serial.println("ERROR: Expected '>'");
    return false;
  }
  return true;
}

bool get3FloatsFromMsg(float (& result) [3]){
  bool success = true;
  float p = 0;
  float y = 0;
  float r = 0;
  byte checksum = 0;

  p = Serial.parseFloat(SKIP_WHITESPACE);
  if((char)Serial.read() != ';'){ Serial.println("ERROR: Expected ';'"); return false;}
  
  y = Serial.parseFloat(SKIP_WHITESPACE);
  if((char)Serial.read() != ';'){ Serial.println("ERROR: Expected ';'"); return false;}
  
  r = Serial.parseFloat(SKIP_WHITESPACE);
  if((char)Serial.read() != ';'){ Serial.println("ERROR: Expected ';'"); return false;}
  
  checksum = Serial.parseInt(SKIP_WHITESPACE);
  if((char)Serial.read() != '>'){ Serial.println("ERROR: Expected '>'"); return false;}

  Serial.print(p); Serial.print(" "); Serial.print(y); Serial.print(" "); Serial.print(r); Serial.print(" "); Serial.println(checksum);

  if(checksum == (byte)((p + y + r + 1))){
    result[0] = p;
    result[1] = y;
    result[2] = r;
  }else{
    success = false;
    Serial.println("ERROR: Checksum does not match!");
  }
  
  return success;
}


void printInfo(){
  Serial.println("========================================");
  Serial.print("Version: "); Serial.print(_version); Serial.print("\tTemp: "); Serial.println(mpu6050.getTemp());
  Serial.print("Pitch: "); Serial.print(pitch); Serial.print("\tYaw: "); Serial.print(yaw); Serial.print("\tRoll: "); Serial.println(roll); 
  Serial.print("SenP: "); Serial.print(pitchSensitivity); Serial.print("\tSenY: "); Serial.print(yawSensitivity); Serial.print("\tSenR: "); Serial.println(rollSensitivity); 
  Serial.print("ExpP: "); Serial.print(pitchExponential); Serial.print("\tExpY: "); Serial.print(yawExponential); Serial.print("\tExpR: "); Serial.println(rollExponential); 
  Serial.print("OffP: "); Serial.print(gyroPitchOffset); Serial.print("\tOffY: "); Serial.print(gyroYawOffset); Serial.print("\tOffR: "); Serial.println(gyroRollOffset); 
  Serial.print("LimP: "); Serial.print(pitchLimit); Serial.print("\tLimY: "); Serial.print(yawLimit); Serial.print("\tLimR: "); Serial.println(rollLimit); 
  Serial.print("ExpMode: "); Serial.print(useExponentialMode); Serial.print("\tSmooth: "); Serial.print(useSmoothness); Serial.print("\tON: "); Serial.println(isOn); 
  Serial.println("========================================");
}

void zeroMPU6050(){
  //Center the Joystick at current position
  offsetPitch += rawPitch;
  offsetRoll += rawRoll;
  offsetYaw += rawYaw;
  
  Serial.println("View reset");
  Serial.print("Pitch: "); Serial.print(rawPitch); Serial.print("\tYaw: "); Serial.print(rawYaw); Serial.print("\tRoll: "); Serial.println(rawRoll); 
  Serial.print("Pitch: "); Serial.print(pitch); Serial.print("\tYaw: "); Serial.print(yaw); Serial.print("\tRoll: "); Serial.println(roll); 
  Serial.print("Offset: "); Serial.print(offsetPitch); Serial.print("\tOffset: "); Serial.print(offsetYaw); Serial.print("\tOffset: "); Serial.println(offsetRoll); 
}

void setSensitivity(float pitch, float yaw, float roll){
  pitchSensitivity = pitch;
  EEPROM.put(EE_PITCH_SENSITIVITY, pitch);

  yawSensitivity = yaw;
  EEPROM.put(EE_YAW_SENSITIVITY, yaw);

  rollSensitivity = roll;
  EEPROM.put(EE_ROLL_SENSITIVITY, roll);

  Serial.println("Uppdated sensitivity values");
  
}

void setExponential(float pitch, float yaw, float roll){
  pitchExponential = pitch;
  EEPROM.put(EE_PITCH_EXPONENTIAL, pitch);

  yawExponential = yaw;
  EEPROM.put(EE_YAW_EXPONENTIAL, yaw);

  rollExponential = roll;
  EEPROM.put(EE_ROLL_EXPONENTIAL, roll);

  Serial.println("Uppdated exponential values");
}

void setOffset(float pitch, float yaw, float roll){
  gyroPitchOffset = pitch;
  EEPROM.put(EE_PITCH_OFFSET, pitch);

  gyroYawOffset = yaw;
  EEPROM.put(EE_YAW_OFFSET, yaw);

  gyroRollOffset = roll;
  EEPROM.put(EE_ROLL_OFFSET, roll);

  mpu6050.setGyroOffsets(gyroPitchOffset, gyroYawOffset, gyroRollOffset);
  Serial.println("Uppdated offset values");
}

void setLimit(float pitch, float yaw, float roll){
  pitchLimit = pitch;
  EEPROM.put(EE_PITCH_ANGLE_LIMIT, pitch);

  yawLimit = yaw;
  EEPROM.put(EE_YAW_ANGLE_LIMIT, yaw);

  rollLimit = roll;
  EEPROM.put(EE_ROLL_ANGLE_LIMIT, roll);

  Serial.println("Uppdated angle limits values");
}

void setExponentialMode(bool enable){
  useExponentialMode = enable;
  EEPROM.put(EE_USE_EXPONENTIAL_MODE, enable);

  Serial.println("Uppdated exponential mode");
}

void setSmoothness(bool enable){
  useSmoothness = enable;
  EEPROM.put(EE_USE_SMOOTHNESS, enable);

  Serial.print("Uppdated smoothness to: "); Serial.println(enable);
}

void setIsOn(bool enable){
  isOn = enable;
  EEPROM.put(EE_IS_ON, enable);

  Serial.println("Uppdated ON / OFF");
}
