const byte gosterge[16] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f,
  0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71};
const byte bArttir = 11;
const byte bAzalt = 12;

int rakam = 0;

void setup() {
  for (int j = 2; j < 9; j++){
    pinMode(j, OUTPUT);
  }
  pinMode(bArttir, INPUT_PULLUP);
  pinMode(bAzalt, INPUT_PULLUP);
}

void loop() {
  if (digitalRead(bArttir) == LOW){
    while (digitalRead(bArttir) == LOW);
    rakam++;
  }
  if (digitalRead(bAzalt) == LOW){
    while (digitalRead(bAzalt) == LOW);
    rakam--;
  }
  if (rakam > 15) rakam = 0;
  if (rakam < 0) rakam = 15;
  for(int i = 0; i < 7; i++){
    bool deger = bitRead(gosterge[rakam], i);
    digitalWrite((i+2), deger);
  }
  delay(20);
}
