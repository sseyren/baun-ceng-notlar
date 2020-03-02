#include "SevSeg.h"
SevSeg sevseg;

const byte button = A0;
bool x = true;

void setup() {
  byte numDigits = 4;
  byte digitPins[] = {10, 11, 12, 13};
  byte segmentPins[] = {9, 2, 3, 5, 6, 8, 7, 4};
  bool resistorsOnSegments = false;
  byte hardwareConfig = COMMON_ANODE;
  bool updateWithDelay = false;
  bool leadingZeros = false;
  sevseg.begin(hardwareConfig, numDigits, digitPins, segmentPins, resistorsOnSegments,
    updateWithDelay, leadingZeros);
  sevseg.setBrightness(90);
  pinMode(button, INPUT_PULLUP);
}

void loop() {
  static unsigned long timer = millis();
  static int salise = 0;
  if(millis() >= timer){
    if(x){
      salise++; timer += 100;
    }
    if (salise > 9999) salise = 0;
    sevseg.setNumber(salise, 1);
  }
  sevseg.refreshDisplay();
  if (digitalRead(button) == LOW){
    while (digitalRead(button) == LOW){
      sevseg.setNumber(salise, 1);
      sevseg.refreshDisplay();
    }
    if (x){
      x = false;
    }else{
      x = true;
    }
  }
}
