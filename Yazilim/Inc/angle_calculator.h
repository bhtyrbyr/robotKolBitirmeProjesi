#ifndef __ANGLE_CALCULATOR_H
#define __ANGLE_CALCULATOR_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes */
#include "stm32f4xx_hal.h"
#include "math.h"
#include "quest_list_obj.h"
#include "servo.h"
/*-----------------------*/

/* Variable Defines */
#define TEST_MODE_1

#define ORIGIN_X					5
#define ORIGIN_Y					5

#define MATH_PI 					3.14159265359

#define ARM_PATH_ONE_LEN	6
#define ARM_PATH_TWO_LEN	7
/*-----------------------*/

/* Function Decleration */
servoMotorsState startCalculate(locationStruct *location);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __ANGLE_CALCULATOR_H */
