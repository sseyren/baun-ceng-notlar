void setup() {
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
}

void flash(){
  for (int i = 2; i < 7; i++){
    digitalWrite(i, LOW);
  }
  delay(250);
  for (int i = 2; i < 7; i++){
    digitalWrite(i, HIGH);
  }
  delay(250);
}

void kara(){
  for (int i = 2; i < 7; i++){
    for (int j = 2; j < 7; j++){
      digitalWrite(j, LOW);
    }
    digitalWrite(i, HIGH);
    delay(100);
  }
  for (int i = 6; i > 1; i--){
    for (int j = 2; j < 7; j++){
      digitalWrite(j, LOW);
    }
    digitalWrite(i, HIGH);
    delay(100);
  }
}

void tren(){
  for (int j = 2; j < 7; j++){
    digitalWrite(j, LOW);
  }
  delay(50);
  for (int i = 2; i < 7; i++){
    digitalWrite(i, HIGH);
    delay(100);
  }
  for (int i = 2; i < 7; i++){
    digitalWrite(i, LOW);
    delay(100);
  }
}

void loop() {
  kara();
  delay(100);
  flash();
  delay(100);
  flash();
  delay(100);
  tren();
  delay(100);
}
