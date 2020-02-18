const byte ledPin = 5;
const byte buttonA = 9;
const byte buttonB = 8;
bool x = true;

void setup() {
  pinMode(ledPin, OUTPUT);
  pinMode(buttonA, INPUT_PULLUP);
  pinMode(buttonB, INPUT_PULLUP);
}

void loop() {
  if (digitalRead(buttonA) == LOW){
    delay(50);
    while (digitalRead(buttonA) == LOW);
    if (x){
      x = false;
      digitalWrite(ledPin, HIGH);
    }else{
      x = true;
      digitalWrite(ledPin, LOW);
    }
  }
}
