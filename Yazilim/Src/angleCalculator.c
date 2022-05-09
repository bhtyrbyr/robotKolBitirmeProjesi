#include "main.h"

static void editLocation(locationStruct *buff);
static servoMotorsState servoAngleCalculator(locationStruct *location);

/**
  * @brief  Calculater motor angle for received quest positions.
	* @param	location, It is the location of the quest.
  * @retval servoMotorsState, are the calculated motor angles.
  */
servoMotorsState startCalculate(locationStruct *location){

	locationStruct buff = *location;
	servoMotorsState servoAngle;

	editLocation(&buff);	
	servoAngle = servoAngleCalculator(&buff);	
	return servoAngle;
}

/**
  * @brief  Arranges the incomung quest location by origin.
	* @param	buff, It is the location of the quest.
  * @retval none,
  */
void editLocation(locationStruct *buff){

	buff -> X -= ORIGIN_X;
	
}

/**
  * @brief  It is the function by which the motor accelerations are calculated.
	* @param	location, It is the location of the quest.
  * @retval servoMotorsState, are the calculated motor angles.
  */
servoMotorsState servoAngleCalculator(locationStruct *location){

	servoMotorsState servoAngleBuff;
	
	float positionDistanceWithoutZaxis = 0;
	float positionSinValueWithoutZaxis = 0;
	
	float servo2AnglePart1 = 0;
	float servo2AnglePart2 = 0;
	
	float positionDistanceWithZaxis = 0;
	float positionSinValueWithZaxis = 0;
	float tempValue = 0;
	
	/*Servo 1 angle calculating-----------------------------------*/
	positionDistanceWithoutZaxis = sqrt( pow( location -> X , 2 ) + pow( location -> Y , 2 ));
	positionSinValueWithoutZaxis = (float)location -> X / positionDistanceWithoutZaxis;
	
	servoAngleBuff.servo1Angle = acos(positionSinValueWithoutZaxis) * 180 / MATH_PI;
	/*Servo 1 angle calcualted------------------------------------*/
	
	/*Servo 2 angle calculating-----------------------------------*/
	positionDistanceWithZaxis = sqrt( pow( location -> X , 2 ) + pow( location -> Y , 2 ) + pow( location -> Z , 2 ));	
	positionSinValueWithZaxis = (float)positionDistanceWithoutZaxis / positionDistanceWithZaxis;
	
	servo2AnglePart1 = acos(positionSinValueWithZaxis) * 180 /MATH_PI;
	
	tempValue = (pow( ARM_PATH_ONE_LEN, 2) + pow(positionDistanceWithZaxis, 2) - pow(ARM_PATH_TWO_LEN, 2)) / (2 * ARM_PATH_ONE_LEN * positionDistanceWithZaxis);
	servo2AnglePart2 = acos(tempValue) * 180 / MATH_PI;

	servoAngleBuff.servo2Angle = servo2AnglePart1 + servo2AnglePart2;
	/*Servo 2 angle calcualted------------------------------------*/
	
	/*Servo 3 angle calculating-----------------------------------*/
	tempValue = (pow( ARM_PATH_ONE_LEN, 2) + pow(ARM_PATH_TWO_LEN, 2) - pow(positionDistanceWithZaxis, 2)) / (2 * ARM_PATH_ONE_LEN * ARM_PATH_TWO_LEN);
	
	servoAngleBuff.servo3Angle = acos(tempValue) * 180 / MATH_PI;
	/*Servo 3 angle calculating-----------------------------------*/
	
	return servoAngleBuff;
	
}
