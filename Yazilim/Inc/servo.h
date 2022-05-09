#ifndef __SERVO_H
#define __SERVO_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes */
#include "stm32f4xx_hal.h"
/*-----------------------*/

/* Variable Defines */
#define NUMBER_OF_SERVO_MOTOR					0x03
#define HOLD_ANGLE										(int16_t)0x0000
#define RELEASE_ANGLE									(int16_t)0x005A

#define KP														0.1
#define KI														10
#define KD														1

typedef struct{
	int16_t servo1Angle;
	int16_t servo2Angle;
	int16_t servo3Angle;
}servoMotorsState;

typedef enum{
	HOLD = 0x00,
	RELEASE
}handleState;

/*-----------------------*/

/* Function Decleration */
HAL_StatusTypeDef runServoMotor(servoMotorsState *angle);
HAL_StatusTypeDef holdOrRelease(handleState state);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __SERVO_H */
