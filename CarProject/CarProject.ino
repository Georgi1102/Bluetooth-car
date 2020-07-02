//#include "AFMotor.h"

//AF_DCMotor motor(1);

#define MOTOR_EN_1_2  10
#define MOTOR_IN1     9
#define MOTOR_IN2     8

void setup() {
  pinMode(13, OUTPUT);
  pinMode(7, OUTPUT);
  Serial.begin(9600);
 // motor1.setSpeed(0); 
}

void loop() {
  String readString;
  String Q;
  
  while(Serial.available()){
    delay(1);
    if(Serial.available()>0){
      char c = Serial.read();
       if(isControl(c))
       {
        break;
       }
       readString += c;
    }
  }
  Q = readString;
  if(Q == "on"){
    Serial.println("On");
    digitalWrite(7, HIGH);
    digitalWrite(13, HIGH);
    //motor logic
      Forward();
   // motor1.setSpeed(255);
   // motor1.run(FORWARD);
  }

  if(Q == "back"){
    Serial.println("Back motor");
    digitalWrite(7, HIGH);
    digitalWrite(13, HIGH);
    //motor logic
      Backwards();
   // motor1.setSpeed(255);
   // motor1.run(FORWARD);
  }

  if(Q == "off"){
    Serial.println("off");
    digitalWrite(7, LOW);
    digitalWrite(13, LOW);
    //motor logic
    analogWrite(MOTOR_EN_1_2, 0);
    digitalWrite(MOTOR_IN1, LOW);
    digitalWrite(MOTOR_IN2, LOW);
  }  
}

//CUSTOM LOGIC
void Forward(void)
  {
    analogWrite(MOTOR_EN_1_2, 255);
    //FORWARD
    digitalWrite(MOTOR_IN1, LOW);
    digitalWrite(MOTOR_IN2, HIGH);
  }

  void Backwards(void)
  {
    analogWrite(MOTOR_EN_1_2, 255);
    //FORWARD
    digitalWrite(MOTOR_IN1, HIGH);
    digitalWrite(MOTOR_IN2, LOW);
  }
