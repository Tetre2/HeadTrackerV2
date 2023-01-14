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
#define EE_USE_EXPONENTIAL_MODE 46
#define EE_USE_SMOOTHNESS 47
#define EE_IS_ON 48

#define MAX_VALUE 32766
#define MAX_MESSAGE_LENGTH 16

float pitch = 0; 
float roll = 0;
float yaw = 0;

float offsetPitch = 0;
float offsetRoll = 0;
float offsetYaw = 0;

//upper and lower limit on the angle of the MPU6050 board range.
int upperLimit = 8192;
int lowerLimit = -8192;

bool expScaleMode = false;

float pitchScale = 37.0;
float yawScale = 37.0;
float rollScale = 1.0;

MPU6050 mpu6050(Wire);

float pitchSensitivity = 0;
float yawSensitivity = 0;
float rollSensitivity = 0;

float pitchExponential = 0;
float yawExponential = 0;
float rollExponential = 0;

float pitchOffset = 0;
float yawOffset = 0;
float rollOffset = 0;

float pitchLimit = 0;
float yawLimit = 0;
float rollLimit = 0;

bool useExponentialMode = false;
bool useSmoothness = false;
bool isOn = false;

void setup() {

  Serial.begin(9600);

  Gamepad.begin();

  Wire.begin();
  mpu6050.begin();
  //mpu6050.calcGyroOffsets(true); //This is is not a necessary call. works fine without it.
  //mpu6050.setGyroOffsets(-2.56, 1.28, -0.88);

  //float f = 523.4;
  //EEPROM.put(EE_PITCH_SENSITIVITY, f);

  EEPROM.get(EE_PITCH_SENSITIVITY, pitchSensitivity);
  EEPROM.get(EE_YAW_SENSITIVITY, yawSensitivity);
  EEPROM.get(EE_ROLL_SENSITIVITY, rollSensitivity);

  EEPROM.get(EE_PITCH_EXPONENTIAL, pitchExponential);
  EEPROM.get(EE_YAW_EXPONENTIAL, yawExponential);
  EEPROM.get(EE_ROLL_EXPONENTIAL, rollExponential);

  EEPROM.get(EE_PITCH_OFFSET, pitchOffset);
  EEPROM.get(EE_YAW_OFFSET, yawOffset);
  EEPROM.get(EE_ROLL_OFFSET, rollOffset);

  EEPROM.get(EE_PITCH_ANGLE_LIMIT, pitchLimit);
  EEPROM.get(EE_YAW_ANGLE_LIMIT, yawLimit);
  EEPROM.get(EE_ROLL_ANGLE_LIMIT, rollLimit);

  EEPROM.get(EE_USE_EXPONENTIAL_MODE, useExponentialMode);
  EEPROM.get(EE_USE_SMOOTHNESS, useSmoothness);
  EEPROM.get(EE_IS_ON, isOn);

}

void zeroMPU6050(){
  //Center the Joystick at current position
  offsetPitch += pitch;
  offsetRoll += roll;
  offsetYaw += yaw;
}

void loop() 
{

  if(Serial.available()){
      reciveMessage();
  }
  
  updatePRY();

  Serial.println(isOn);
  
  Gamepad.yAxis(pitch);
  Gamepad.xAxis(yaw);
  Gamepad.zAxis(roll);
  Gamepad.write();

}

void updatePRY(){
  mpu6050.update();
  pitch = mpu6050.getAngleX();
  roll = mpu6050.getAngleY();
  yaw = mpu6050.getAngleZ();

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

  // Apply offsets
  pitch -= offsetPitch;
  roll -= offsetRoll;
  yaw -= offsetYaw;

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
//<6> //Toggle Smoothness
//<7> //run calibrateGyro
//<8> //Turn on/off

void reciveMessage(){
  String msg = new char[MAX_MESSAGE_LENGTH];
  while(Serial.available() && msg.length() != MAX_MESSAGE_LENGTH){
        char inChar = (char)Serial.read();
        msg += inChar;
    }

  // Get start and end index for message
  int startIndex = 0;
  int endIndex = 0;
  for(int i = 0; i < msg.length(); i++){
    if(msg[i] == '<'){
      startIndex = i;
    }
    if(msg[i] == '>'){
      endIndex = i;
    }
  }

  // substring the message, POSSIBLE overflow on end index
  msg = msg.substring(startIndex, endIndex + 1);

  //return if not correct message type
  if(msg[0] != '<' || msg[msg.length() - 1] != '>'){
      return;
  }

  // print info to client
  if(msg[1] == '0'){
      Serial.println("nnnnn");
  }

  // zero the gyros
  if(msg[1] == '1'){
      zeroMPU6050();
  }
  
}
