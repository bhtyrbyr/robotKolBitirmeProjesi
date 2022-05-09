#ifndef __DO_QUEST_H
#define __DO_QUEST_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes */
#include "stm32f4xx_hal.h"
#include "quest_list_obj.h"
#include "servo.h"
/*-----------------------*/

/* Variable Defines */
typedef enum{
	BUSSY = 0x00,
	AVAILABLE
}machineState;

typedef struct{
	servoMotorsState	angels;
	handleState				isHolding;
	locationStruct		location;
}machineInfo;

/*-----------------------*/

/* Function Decleration */
machineState			isMachineAvaliable(void);
HAL_StatusTypeDef	doQuest(rotation *newQuest);
HAL_StatusTypeDef checkMachineInfo(void);
servoMotorsState calculateServoMotorAngle(rotation *quest, uint8_t startOrEnd);
HAL_StatusTypeDef startMove(servoMotorsState *servoMotorsAngle);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __DO_QUEST_H */
