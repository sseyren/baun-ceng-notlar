const byte gosterge[10] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f};

int rakam = 0;

void setup() {
  for (int j = 2; j < 9; j++){
    pinMode(j, OUTPUT);
  }
}

void loop() {
  rakam++;
  if (rakam > 9){
    rakam = 0;
  }
  for(int i = 0; i < 7; i++){
    bool deger = bitRead(gosterge[rakam], i);
    digitalWrite((i+2), deger);
  }
  delay(500);
}
