#ifndef __RING_BUFFER_H
#define __RING_BUFFER_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

#define MAX_RING_BUFFER	0x15

typedef struct{
	uint8_t	ringBuffer[MAX_RING_BUFFER];
	int8_t	head;
	int8_t	tail;
	uint8_t	count;
}ringBuffer;

//ringBuffInit
ringBuffer ringBufferInit(ringBuffer *queue);

//ringBuffEmpty
int8_t ringBufferisEmpty(ringBuffer *queue);

//ringBuffFullringBufferisFull
int8_t ringBufferisFull(ringBuffer *queue);

//ringBuffGet
uint8_t ringBufferGet(ringBuffer *queue);

//ringBuffPush
HAL_StatusTypeDef	ringBufferPush(ringBuffer *queue, uint8_t data);

//ringBufferClear
HAL_StatusTypeDef ringBufferClear(ringBuffer *queue);

#ifdef __cplusplus
}
#endif

#endif /* __RING_BUFFER_H */

