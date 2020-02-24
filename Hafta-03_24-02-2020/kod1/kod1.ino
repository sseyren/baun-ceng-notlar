int potPin = A0;
int ledPort = 2;

void setup() {
  Serial.begin(9600);
  Serial.println("Analog input okuma örneği ");
  pinMode(ledPort, OUTPUT);
}

void loop() {
  int deger = analogRead(potPin);

  float hesap = (5.0 * deger) / 1023.0;
  Serial.println(hesap);

  if(deger > 300 && deger < 700) {
    digitalWrite(ledPort, HIGH);
  } else {
    digitalWrite(ledPort, LOW);
  }

  delay(100);
}
