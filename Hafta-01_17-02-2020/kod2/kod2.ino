const int rp = 9;
const int gp = 10;
const int bp = 11;

void setup() {
  pinMode(rp, OUTPUT);
  pinMode(gp, OUTPUT);
  pinMode(bp, OUTPUT);
}

void loop() {
  for (int i = 0; i < 255; i+10){
    for (int j = 0; j < 255; j+10){
      for (int k = 0; k < 255; k+10){
        digitalWrite(rp, i);
        digitalWrite(gp, j);
        digitalWrite(bp, k);
        delay(50);
      }
    }
  }
}
