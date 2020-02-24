int rPin = 9;
int gPin = 10;
int bPin = 11;

void setup() {
  pinMode(rPin, OUTPUT);
  pinMode(gPin, OUTPUT);
  pinMode(bPin, OUTPUT);
  Serial.begin(9600);
  Serial.println(" ");
}

void loop() {
  if(Serial.available()) {
    int r = Serial.parseInt();
    int g = Serial.parseInt();
    int b = Serial.parseInt();

    analogWrite(rPin, 255-r);
    analogWrite(gPin, 255-g);
    analogWrite(bPin, 255-b);
  }
}
