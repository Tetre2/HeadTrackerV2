#include "HID-Project.h"    //https://github.com/NicoHood/HID
#include <MPU6050_tockn.h>  //https://github.com/tockn/MPU6050_tockn
#include <Wire.h>

MPU6050 mpu6050(Wire);
//MPU6050 mpu6050(Wire, 0.01, 0.99);

#define MAX_VALUE 32766
#define MAX_MESSAGE_LENGTH 16

float pitch = 0; //
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

void setup() {

  Serial.begin(9600);

  Gamepad.begin();

  Wire.begin();
  mpu6050.begin();
  mpu6050.calcGyroOffsets(true); //This is is not a necessary call. works fine without it.
  //mpu6050.setGyroOffsets(-2.56, 1.28, -0.88);

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

  float p = map(pitch, lowerLimit, upperLimit, -MAX_VALUE, MAX_VALUE);
  float y = map(yaw, lowerLimit, upperLimit, -MAX_VALUE, MAX_VALUE);
  float r = map(roll, -100, 100, -127, 127);

  Serial.print(pitch);
  Serial.print(" ");
  Serial.print(p);
  Serial.print(" ");
  Serial.print(yaw);
  Serial.print(" ");
  Serial.print(y);
  Serial.print(" ");
  Serial.print(roll);
  Serial.print(" ");
  Serial.print(r);
  Serial.println();
  
  Gamepad.yAxis(p);
  Gamepad.xAxis(y);
  Gamepad.zAxis(roll);
  Gamepad.write();

}

//New Protocol - Using 0 - 9 as commands
//<7> // calibrate gyro
//<8> // reset view
//<9 sensX sensY sensZ expX expY expZ loop onOff debug checksum>
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

  // zero the gyros
  if(msg[1] == '8'){
      zeroMPU6050();
  }
  
}
