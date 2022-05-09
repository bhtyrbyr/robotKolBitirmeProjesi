#include "main.h"

static machineState state = AVAILABLE;
static machineInfo info;
static servoMotorsState servoMotors;

/**
  * @brief  Return the machine state.
	* @param	none
  * @retval machineState, It is state the machine.
  */
machineState isMachineAvaliable(void){
	
	return state;
	
}

/**
  * @brief  It is the main function that fulfills the new incoming quest.
	* @param	newQuest, It is the data structure that carries the new quest.
  * @retval HAL_StatusTypeDef, Checks whether the task has been completed.
  */
HAL_StatusTypeDef doQuest(rotation *newQuest){
	
	state = BUSSY;
#ifdef TEST_MODE
	uint32_t timer = 3000;
	while(timer){
		timer--;
	}
#endif

#ifndef TEST_MODE
	/* Quest start-------------------------------------*/
	servoMotorsState servoMotorAngels = calculateServoMotorAngle(newQuest, 0x00);
	while(startMove(&servoMotorAngels) != HAL_OK);
	while(holdOrRelease(HOLD) != HAL_OK);
	info.isHolding = HOLD;
	
	/* Quest end---------------------------------------*/
	servoMotorAngels = calculateServoMotorAngle(newQuest, 0x01);
	while(startMove(&servoMotorAngels) != HAL_OK);
	while(holdOrRelease(RELEASE) != HAL_OK);
	info.isHolding = RELEASE;
#endif

	state = AVAILABLE;
	return HAL_OK;
	
}

/**
  * @brief  Function to check machine info.
	* @param	none.
  * @retval HAL_StatusTypeDef, check the function is complate.
  */
HAL_StatusTypeDef checkMachineInfo(void){
	
	/*
	*/
	
	return HAL_OK;
	
}

/**
  * @brief  It is the function that calculates the angles of the motors for the task.
	* @param	quest, It is the data structure that carries the new quest.
	*	@param	startOrtEnd, Determines whether to be calculated for the beginning or the end.
  * @retval HAL_StatusTypeDef, check the function is complate.
  */
servoMotorsState calculateServoMotorAngle(rotation *quest, uint8_t startOrEnd){
	
	servoMotorsState buff;
	
	if(startOrEnd == 0x00){		
		startCalculate(&quest -> Start);		
	}	
	else{		
		startCalculate(&quest -> End);		
	}	
	return buff;
	
}

/**
  * @brief  It is the function that will make the motors move.
	* @param	servoMotorsAngle, It is the data structure that stores the angle values to which the motors will be adjusted.
  * @retval HAL_StatusTypeDef, check the function is complate.
  */
HAL_StatusTypeDef startMove(servoMotorsState *servoMotorsAngle){
	
	servoMotors = *servoMotorsAngle;	
	runServoMotor(servoMotorsAngle);	
	return HAL_OK;
	
}
