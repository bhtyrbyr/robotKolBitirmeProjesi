#include "main.h"

/**
  * @brief  Initilation the ringBuffer
	* @param	*sQueue	=	the ringBuffer object.
  * @retval none
  */
ringBuffer ringBufferInit(ringBuffer *queue)
{
	uint8_t loop = 0x00;
	for(loop = 0x00; loop < sizeof(queue -> ringBuffer); loop++){
		queue -> ringBuffer[loop] = 0x00;
	}
	queue -> head = 0x00;
	queue -> tail = 0x00;
	queue -> count = 0x00;
	return *queue;
}

/**
  * @brief	Check the if the sQueue is empty.
	* @param	*sQueue	=	the ringBuffer object.
  * @retval if sQueue state of empty, return 1.
  */
int8_t ringBufferisEmpty(ringBuffer *queue)
{
	return (0x00 == queue -> count);
}

/**
  * @brief	Check the if the sQueue is full.
	* @param	*sQueue	=	the ringBuffer object.
  * @retval if sQueue state of empty, return 1.
  */
int8_t ringBufferisFull(ringBuffer *queue)
{
	return (MAX_RING_BUFFER == queue -> count);
}

/**
  * @brief	Get data in the sQueue.
	* @param	*sQueue	=	the ringBuffer object.
  * @retval buff		=	First data in ringBuffer.
  */
uint8_t ringBufferGet(ringBuffer *queue)
{
	uint8_t buff;
	if(!ringBufferisEmpty(queue))
	{
		buff = queue -> ringBuffer[queue -> tail];
		queue -> tail = (queue ->tail + 1) % MAX_RING_BUFFER;
		queue -> count--;
	}
	else{
		buff = HAL_ERROR;
	}
	return buff;
}

/**
  * @brief	Push data to the sQueue.
	* @param	*sQueue	=	the ringBuffer object.
  * @retval Hal_StatusTypeDef	=	Is it correct to insert the data.
  */
HAL_StatusTypeDef	ringBufferPush(ringBuffer *queue, uint8_t data)
{
	if(!ringBufferisFull(queue))
	{
		queue -> ringBuffer[queue -> head] = data;
		queue -> head = (queue -> head + 1) % MAX_RING_BUFFER;
		queue -> count++;
		return HAL_OK;
	}else{ return HAL_ERROR;}
}

/**
  * @brief	Clear all data in the sQueue.
	* @param	*sQueue	=	the ringBuffer object.
  * @retval Hal_StatusTypeDef	=	Has the data been cleared.
  */
HAL_StatusTypeDef ringBufferClear(ringBuffer *queue){

	
	uint8_t loop = 0x00;
	for(loop = 0x00; loop < sizeof(queue -> ringBuffer); loop++){
		queue -> ringBuffer[loop] = 0x00;
	}
	queue -> head = 0x00;
	queue -> tail = 0x00;
	queue -> count = 0x00;
	return HAL_OK;
	
}
