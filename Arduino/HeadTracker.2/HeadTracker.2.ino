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

#define MAX_VALUE 32766
#define MAX_MESSAGE_LENGTH 48

float rawPitch = 0; 
float rawYaw = 0;
float rawRoll = 0;

float pitch = 0; 
float yaw = 0;
float roll = 0;

float offsetPitch = 0;
float offsetYaw = 0;
float offsetRoll = 0;

//upper and lower limit on the angle of the MPU6050 board range.
int upperLimit = 8192;
int lowerLimit = -8192;

bool expScaleMode = false;

float pitchScale = 37.0;
float yawScale = 37.0;
float rollScale = 1.0;

MPU6050 mpu6050(Wire);

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

float floatCreationBuffer[3];
String messageBuffer = new char[MAX_MESSAGE_LENGTH];

void setup() {

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

  Serial.begin(9600);
  while (!Serial); // wait for Leonardo enumeration, others continue immediately

  Gamepad.begin();

  Wire.begin();
  mpu6050.begin();
  //mpu6050.calcGyroOffsets(true); //This is is not a necessary call. works fine without it.
  mpu6050.setGyroOffsets(gyroPitchOffset, gyroYawOffset, gyroRollOffset);

  
  /*byte b = 1;
  EEPROM.put(EE_VERSION, b);

  float f = 123.00f;
  EEPROM.put(EE_PITCH_SENSITIVITY, f);
  EEPROM.put(EE_YAW_SENSITIVITY, f);
  EEPROM.put(EE_ROLL_SENSITIVITY, f);

  EEPROM.put(EE_PITCH_EXPONENTIAL, f);
  EEPROM.put(EE_YAW_EXPONENTIAL, f);
  EEPROM.put(EE_ROLL_EXPONENTIAL, f);
  
  EEPROM.put(EE_PITCH_OFFSET, f);
  EEPROM.put(EE_YAW_OFFSET, f);
  EEPROM.put(EE_ROLL_OFFSET, f);
  
  EEPROM.put(EE_PITCH_ANGLE_LIMIT, f);
  EEPROM.put(EE_YAW_ANGLE_LIMIT, f);
  EEPROM.put(EE_ROLL_ANGLE_LIMIT, f);

  bool bo = true;
  EEPROM.put(EE_USE_EXPONENTIAL_MODE, bo);
  EEPROM.put(EE_USE_SMOOTHNESS, bo);
  EEPROM.put(EE_IS_ON, bo);*/
  


}

void loop() 
{  
  if(Serial.available()){
      reciveMessage();
  }
  
  updatePRY();
  
  Gamepad.yAxis(pitch);
  Gamepad.xAxis(yaw);
  Gamepad.zAxis(roll);
  Gamepad.write();

}

void updatePRY(){
  mpu6050.update();
  rawPitch = mpu6050.getAngleX();
  rawRoll = mpu6050.getAngleY();
  rawYaw = mpu6050.getAngleZ();
  
  // Apply offsets
  pitch = rawPitch - offsetPitch;
  roll = rawRoll - offsetRoll;
  yaw = rawYaw - offsetYaw;

  
  if (expScaleMode) {
    pitch = (0.001422076 * pitch * pitch * pitchScale) * (pitch / abs(pitch));
    roll = (0.001422076 * roll * roll * rollScale) * (roll / abs(roll));
    yaw = (0.001422076 * yaw * yaw * yawScale) * (yaw / abs(yaw));
  }
  else
  {
    // and scale to out target range plus a 'sensitivity' factor;
    pitch = (pitch * pitchScale);
    roll = (roll * rollScale);
    yaw = (yaw * yawScale);
  }

  pitch = map(pitch, lowerLimit, upperLimit, -MAX_VALUE, MAX_VALUE);
  yaw = map(yaw, lowerLimit, upperLimit, -MAX_VALUE, MAX_VALUE);
  roll = map(roll, -100, 100, -127, 127);
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
  while(Serial.available() && messageBuffer.length() != MAX_MESSAGE_LENGTH){
        char inChar = (char)Serial.read();
        messageBuffer += inChar;
    }

  
  Serial.print("Arduino got: "); Serial.println(messageBuffer);

  Serial.print("Arduino got: ");
  for(int i = 0; i < messageBuffer.length(); i++){
    Serial.print((uint8_t)messageBuffer[i], HEX);
  }
  Serial.println();

  // Get start and end index for message
  int startIndex = 0;
  int endIndex = 0;
  for(int i = 0; i < messageBuffer.length(); i++){
    if(messageBuffer[i] == '<'){
      startIndex = i;
    }
    if(messageBuffer[i] == '>'){
      endIndex = i;
    }
  }
  // substring the message
  messageBuffer = messageBuffer.substring(startIndex, endIndex + 1);

  //return if not correct message type
  if(messageBuffer[0] != '<' || messageBuffer[messageBuffer.length() - 1] != '>'){
      return;
  }


  //Convert msg to a char array
  char messageCharArray[messageBuffer.length() + 1];
  messageBuffer.toCharArray(messageCharArray, messageBuffer.length() + 1);

  //<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
  if(messageBuffer[1] == '0'){
      printInfo();
  }

  //<1> //reset view
  if(messageBuffer[1] == '1'){
      zeroMPU6050();
  }

  //<2 sensX sensY sensZ checksum>
  if(messageBuffer[1] == '2'){
    getFloatsFromMsg(floatCreationBuffer, messageCharArray, messageBuffer.length() + 1);
    Serial.print(floatCreationBuffer[0]); Serial.print(" "); Serial.print(floatCreationBuffer[1]); Serial.print(" "); Serial.println(floatCreationBuffer[2]);

    if(floatCreationBuffer[0] == -1.0f && floatCreationBuffer[1] == -1.0f && floatCreationBuffer[2] == -1.0f){
      Serial.println("ERROR: Checksum does not match!");
      return;
    }

    setSensitivity(floatCreationBuffer[0], floatCreationBuffer[1], floatCreationBuffer[2]);
  
  }
    
  
  //<3 expX expY expZ checksum>
  if(messageBuffer[1] == '3'){
    getFloatsFromMsg(floatCreationBuffer, messageCharArray, messageBuffer.length() + 1);
    Serial.print(floatCreationBuffer[0]); Serial.print(" "); Serial.print(floatCreationBuffer[1]); Serial.print(" "); Serial.println(floatCreationBuffer[2]);

    if(floatCreationBuffer[0] == -1.0f && floatCreationBuffer[1] == -1.0f && floatCreationBuffer[2] == -1.0f){
      Serial.println("ERROR: Checksum does not match!");
      return;
    }

    setExponential(floatCreationBuffer[0], floatCreationBuffer[1], floatCreationBuffer[2]);
  }

  //<4 offsetX offsetY offsetZ checksum>
  if(messageBuffer[1] == '4'){
    getFloatsFromMsg(floatCreationBuffer, messageCharArray, messageBuffer.length() + 1);
    Serial.print(floatCreationBuffer[0]); Serial.print(" "); Serial.print(floatCreationBuffer[1]); Serial.print(" "); Serial.println(floatCreationBuffer[2]);

    if(floatCreationBuffer[0] == -1.0f && floatCreationBuffer[1] == -1.0f && floatCreationBuffer[2] == -1.0f){
      Serial.println("ERROR: Checksum does not match!");
      return;
    }

    setOffset(floatCreationBuffer[0], floatCreationBuffer[1], floatCreationBuffer[2]);
  }

  //<5 limitX limitY limitZ checksum>
  if(messageBuffer[1] == '5'){
    getFloatsFromMsg(floatCreationBuffer, messageCharArray, messageBuffer.length() + 1);
    Serial.print(floatCreationBuffer[0]); Serial.print(" "); Serial.print(floatCreationBuffer[1]); Serial.print(" "); Serial.println(floatCreationBuffer[2]);

    if(floatCreationBuffer[0] == -1.0f && floatCreationBuffer[1] == -1.0f && floatCreationBuffer[2] == -1.0f){
      Serial.println("ERROR: Checksum does not match!");
      return;
    }

    setLimit(floatCreationBuffer[0], floatCreationBuffer[1], floatCreationBuffer[2]);
  }

  //<6 bool> //Toggle Smoothness
  if(messageBuffer[1] == '6'){
    if(messageBuffer[2] == '0'){
      setSmoothness(false);
    }else if(messageBuffer[2] == '1'){
      setSmoothness(true);
    }else{
      Serial.println("ERROR: Checksum does not match!");
    }
  }

  //<7> //run calibrateGyro
  if(messageBuffer[1] == '7'){
    mpu6050.calcGyroOffsets(true);
    Serial.println("Gyro is Running!");
  }

  //<8 bool> //Turn on/off
  if(messageBuffer[1] == '8'){
    if(messageBuffer[2] == '0'){
      setIsOn(false);
    }else if(messageBuffer[2] == '1'){
      setIsOn(true);
    }else{
      Serial.println("ERROR: Checksum does not match!");
    }
  }

  //<9 bool> //Use Exponential
  if(messageBuffer[1] == '9'){
    if(messageBuffer[2] == '0'){
      setExponentialMode(false);
    }else if(messageBuffer[2] == '1'){
      setExponentialMode(true);
    }else{
      Serial.println("ERROR: Checksum does not match!");
    }
  }

  messageBuffer = "";
}

void getFloatsFromMsg(float (& result) [3], char message[], int len){
  float p = 0;
  float y = 0;
  float r = 0;
  float checksum = 0;

  int lenOfPitch = 0;
  int lenOfYaw = 0;
  int lenOfRoll = 0;
  int lenOfChecksum = 0;
  
  int val = 0;
  for(int i = 2; i < len; i++){
    if(message[i] == ';'){
      if(val == 0){
        lenOfPitch = i - 2;
      }else if(val == 1){
        lenOfYaw = i - (lenOfPitch + 3);
      }else if(val == 2){
        lenOfRoll = i - (lenOfPitch + lenOfYaw + 4);
      }
      val++;
    }

    if(message[i] == '>'){
      lenOfChecksum = i - (lenOfPitch + lenOfYaw + lenOfRoll + 5);
      break;
    }
  }
  
  p = bytesToFloat(lenOfPitch, message + 2);
  
  y = bytesToFloat(lenOfYaw, message + 2 + lenOfPitch + 1);
  
  r = bytesToFloat(lenOfRoll, message + 2 + lenOfPitch + 1 + lenOfYaw + 1);
  
  checksum = bytesToFloat(lenOfChecksum, message + 2 + lenOfPitch + 1 + lenOfYaw + 1 + lenOfRoll + 1);

  Serial.print(p); Serial.print(" "); Serial.print(y); Serial.print(" "); Serial.print(r); Serial.print(" "); Serial.println(checksum);

  if(checksum == (byte)((p + y + r))){
    result[0] = p;
    result[1] = y;
    result[2] = r;
  }else{
    result[0] = -1;
    result[1] = -1;
    result[2] = -1;
  }

}

float bytesToFloat(int lengthOfFloat, int address){
  char destP[lengthOfFloat + 1];
  memcpy (destP, address, lengthOfFloat);
  return atof(destP);
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

  Serial.println("Uppdated smoothness");
}

void setIsOn(bool enable){
  isOn = enable;
  EEPROM.put(EE_IS_ON, enable);

  Serial.println("Uppdated ON / OFF");
}
