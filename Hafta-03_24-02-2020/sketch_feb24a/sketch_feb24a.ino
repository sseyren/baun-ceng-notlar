int potPin = A0;
int ledPort = 2;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Analog input okuma örneği ");
  pinMode(ledPort, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  int deger = analogRead(potPin);
  Serial.println(deger);
  if(deger > 300 && deger < 700) {
    digitalWrite(ledPort, HIGH);
  } else {
    digitalWrite(ledPort, LOW);
  }
  delay(100);
}
