#include "main.h"

uint8_t sIncomingMessage = 0x00;
ringBuffer sQueue;
static servoMotorsState startPosAngle;

static void startPos(void);

int main(void){
	
	HAL_Init();
	SystemClock_Config();
	system_init();
	sQueue = ringBufferInit(&sQueue);
	startPos();
	while(1){
	}
	
}

/**
  * @brief  Return the arm to its start position.
	* @param	none
  * @retval none
  */
static void startPos(void){
	
	/* Set start position--------------------------------*/
	startPosAngle.servo1Angle = 0;
	startPosAngle.servo2Angle = 0;
	startPosAngle.servo3Angle = 0;
	
	runServoMotor(&startPosAngle);
	
}
