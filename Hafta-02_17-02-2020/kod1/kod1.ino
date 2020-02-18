const int LED = 2;
const int DELAY = 500;

void setup() {
  pinMode(LED, OUTPUT);
}

void loop() {
  for (byte i = 0; i < 10; i++){
    digitalWrite(LED, HIGH);
    delay(DELAY);
    digitalWrite(LED, LOW);
    delay(DELAY);
  }
  while(true){};
}
