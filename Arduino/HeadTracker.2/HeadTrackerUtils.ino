
void loadDataFromEEPROM(){
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
}

//Calculates the average of the given array
float getAverage(float (&averageBuffer) [AVERAGE_BUFFER_SIZE]){
  float average = 0;
  for(int i = 0; i < AVERAGE_BUFFER_SIZE; i++){
    average += averageBuffer[i];
  }
  
  return average / AVERAGE_BUFFER_SIZE;
}

//Calculates the max delta of the values in the average buffer
float getDeltaFromAverage(float (&averageBuffer) [AVERAGE_BUFFER_SIZE]){
  float maxDelta = 0;
  float average = getAverage(averageBuffer);
  for(int i = 0; i < AVERAGE_BUFFER_SIZE; i++){
    maxDelta = max(maxDelta, abs(average - averageBuffer[i]));
  }
  Serial.println(maxDelta);
  return maxDelta;
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
