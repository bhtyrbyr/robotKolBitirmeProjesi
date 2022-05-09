#ifndef __PC_CONTACT_H
#define __PC_CONTACT_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes */
#include "stm32f4xx_hal.h"
#include "system_init.h"
#include <stdbool.h>
#include "math.h"
#include "ring_buffer.h"
/*-----------------------*/

/* Variable Defines */

#define ASCII_TO_INT 			0x30

#define MSG_STRT_CHAR		'{'
#define MSG_END_CHAR		'}'
/*-----------------------*/

/* Function Decleration */
HAL_StatusTypeDef sendMessagetoPC(uint8_t *message, uint8_t messageSize);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __PC_CONTACT_H */
