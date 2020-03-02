#include "DHT.h"

#define DHTPIN 2
#define DHTTYPE DHT22
#define BUZZER 3

DHT dht(DHTPIN, DHTTYPE);

void setup() {
  pinMode(BUZZER, OUTPUT);
  Serial.begin(9600);
  dht.begin();
}

void loop() {
  delay(1000);
  
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  float f = dht.readTemperature(true);
  
  if (isnan(h) || isnan(t) || isnan(f)) {
    Serial.println(F("Failed to read from DHT sensor!"));
    return;
  }

  if (t > 30){
    digitalWrite(BUZZER, HIGH);
  }else{
    digitalWrite(BUZZER, LOW);
  }

  float hif = dht.computeHeatIndex(f, h);
  float hic = dht.computeHeatIndex(t, h, false);

  Serial.print(F("Humidity: "));
  Serial.print(h);
  Serial.print(F("%  Temperature: "));
  Serial.print(t);
  Serial.print(F("°C "));
  Serial.print(f);
  Serial.print(F("°F  Heat index: "));
  Serial.print(hic);
  Serial.print(F("°C "));
  Serial.print(hif);
  Serial.println(F("°F"));
}
