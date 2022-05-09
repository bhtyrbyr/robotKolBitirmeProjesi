#include "main.h"
#include "string.h"

#ifdef UART_IT

extern UART_HandleTypeDef UART_Init;
extern uint8_t sIncomingMessage;
extern ringBuffer sQueue;

/**
  * @brief  Send the incomming message to the PC.
	* @param	message, It is message.
	*	@param	messageSize, It is length the message.
  * @retval HAL_StatusTypeDef, check the function is complate.
  */
HAL_StatusTypeDef sendMessagetoPC(uint8_t *message, uint8_t messageSize){
	
	HAL_UART_Transmit(&UART_Init, message, messageSize, HAL_MAX_DELAY);
	
	return HAL_OK;
}

void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
   if (huart -> Instance == UART_SLC)
  {
		ringBufferPush(&sQueue, sIncomingMessage);
		HAL_UART_Receive_IT(huart, &sIncomingMessage, MAX_UART_RECIVE_SIZE);
  }
}

#endif /* UART_IT */
