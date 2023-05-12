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

#define GAMEPAD_MAX_VALUE 32000
#define MAX_MESSAGE_LENGTH 48
#define AVERAGE_BUFFER_SIZE 20 

float pitch = 0; 
float yaw = 0;
float roll = 0;

float offsetPitch = 0;
float offsetYaw = 0;
float offsetRoll = 0;

MPU6050 mpu6050(Wire, 0.001, 0.999);

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
long updateBufferTimer = 0;

float lerpNumbPitch = 0;
float lerpNumbYaw = 0;
float lerpNumbRoll = 0;


void setup() {

  delay(1000);

  Serial.begin(9600);
  while (!Serial); // wait for Leonardo enumeration, others continue immediately
  Serial.flush();
  
  loadDataFromEEPROM();
  
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
  }
}


void updatePRY(){
  mpu6050.update();
  float rawPitch = mpu6050.getAngleX();
  float rawRoll = mpu6050.getAngleY();
  float rawYaw = mpu6050.getAngleZ();

  pitch = rawPitch; 
  yaw = rawYaw;
  roll = rawRoll;

  if(millis() - updateBufferTimer > 20){
      //rotates thought the buffer and updates the oldes value
      averageBufferPitch[averageBufferIndex] = rawPitch;
      averageBufferYaw[averageBufferIndex] = rawYaw;
      averageBufferRoll[averageBufferIndex] = rawRoll;
      averageBufferIndex = (averageBufferIndex + 1) % AVERAGE_BUFFER_SIZE;
      
      updateBufferTimer = millis();
  }

  if(useSmoothness){
      
      if(getDeltaFromAverage(averageBufferPitch) < 0.4){
          pitch = (getAverage(averageBufferPitch) * 0.05) + (lerpNumbPitch * 0.95);
      }else{
          pitch = (rawPitch * 0.05) + (lerpNumbPitch * 0.95);
      }
      lerpNumbPitch = pitch;
      
      if(getDeltaFromAverage(averageBufferYaw) < 0.4){
          yaw = (getAverage(averageBufferYaw) * 0.05) + (lerpNumbYaw * 0.95);  
      }else{
          yaw = (rawYaw * 0.05) + (lerpNumbYaw * 0.95);
      }
      lerpNumbYaw = yaw;
      
      if(getDeltaFromAverage(averageBufferRoll) < 0.4){
          roll = (getAverage(averageBufferRoll) * 0.5) + (lerpNumbRoll * 0.95);  
      }else{
          roll = (rawRoll * 0.5) + (lerpNumbRoll * 0.95);  
      }
      lerpNumbRoll = roll;
  }

  // Apply offsets
  pitch -= offsetPitch;
  roll -= offsetRoll;
  yaw -= offsetYaw;
  
  // Apply angel limits
  pitch = constrain(pitch, -pitchLimit, pitchLimit);
  yaw = constrain(yaw, -yawLimit, yawLimit);
  roll = constrain(roll, -rollLimit, rollLimit);

  float gamepadPitch = (pitch * pitchSensitivity);
  float gamepadYaw = (yaw * yawSensitivity);
  float gamepadRoll = (roll * rollSensitivity);

  if (useExponentialMode) {//somewhere around 0.001422076 is good
    gamepadPitch = (pitchExponential / 10000 * pitch * pitch * pitchSensitivity) * (pitch / abs(pitch));
    gamepadRoll = (rollExponential / 10000 * roll * roll * rollSensitivity) * (roll / abs(roll));
    gamepadYaw = (yawExponential / 10000 * yaw * yaw * yawSensitivity) * (yaw / abs(yaw));
  }

  gamepadPitch = constrain(gamepadPitch, -GAMEPAD_MAX_VALUE, GAMEPAD_MAX_VALUE);
  gamepadYaw = constrain(gamepadYaw, -GAMEPAD_MAX_VALUE, GAMEPAD_MAX_VALUE);
  gamepadRoll = constrain(gamepadRoll, -127, 127);

  /*if(millis() - timer > 10){
    Serial.println("---");
    Serial.print(rawPitch); Serial.print(" "); Serial.print(rawYaw); Serial.print(" "); Serial.println(rawRoll);
    Serial.print(pitch); Serial.print(" "); Serial.print(yaw); Serial.print(" "); Serial.println(roll);
    Serial.print(gamepadPitch); Serial.print(" "); Serial.print(gamepadYaw); Serial.print(" "); Serial.println(gamepadRoll);
    timer = millis();
  }*/

  Gamepad.yAxis(gamepadPitch);
  Gamepad.xAxis(gamepadYaw);
  Gamepad.zAxis(gamepadRoll);
  Gamepad.write();

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
  offsetPitch += pitch;
  offsetRoll += roll;
  offsetYaw += yaw;
  
  Serial.println("View reset");
  Serial.print("Pitch: "); Serial.print(pitch); Serial.print("\tYaw: "); Serial.print(yaw); Serial.print("\tRoll: "); Serial.println(roll); 
  Serial.print("Offset: "); Serial.print(offsetPitch); Serial.print("\tOffset: "); Serial.print(offsetYaw); Serial.print("\tOffset: "); Serial.println(offsetRoll); 
}
