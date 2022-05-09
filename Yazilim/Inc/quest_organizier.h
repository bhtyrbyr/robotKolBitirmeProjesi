#ifndef __QUEST_ORGANIZIER_H
#define __QUEST_ORGANIZIER_H

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

/* Enable Defines */
/*-----------------------*/

/* Variable Defines */

#define	MAX_MSG_LEN						18
#define OPEN_MSG							"o}"

#define SAVE_OK_MSG						"s}"
#define SAVE_ERR_MSG					"s!}"
#define	DEL_OK_MSG						"d}"
#define	DEL_ERR_MSG						"d!}"
#define	QUEST_LST_MSG					"l~"
#define QUEST_LST_EMPTY_MSG		"l!}"
#define	QUEST_MSG							"%d,%d,%d/%d,%d,%d~"
#define QUEST_MSG_END					"%d,%d,%d/%d,%d,%d}"
#define IS_BUSSY_MSG					"z}"
#define IS_AVALIABLE_MSG			"z!}"
#define	IS_HOLDING_MSG				"y}"
#define IS_DOESNT_HOLD_MSG		"y!}"

#define	OPEN_CHAR							'o' 
#define	SAVE_CHAR							's'
#define	DELETE_CHAR						'd'
#define	LIST_CHAR							'l'
#define QUEST_SPLIT_CHAR			'~'

typedef enum{
	READ_OK,
	READ_ERROR
}readRingBuffer;

typedef enum{
	MSG_IN = 0,
	MSG_IN_NOT
}haveMessage;

typedef enum{
	SPLIT_OK = 0x00,
	SPLIT_ERROR
}splitState;

typedef enum{
	READY = 0,
	READY_NOT
}PreparationState;

typedef enum{
	SAVE_OK = 0,
	SAVE_ERR
}saveQuest;

typedef enum{
	DEL_OK = 0,
	DEL_ERR
}deleteQuest;

typedef enum{
	CHECKED = 0,
	CHECK_NOT
}checkList;
/*-----------------------*/

/* Function Decleration */
readRingBuffer	startReadRingBuffer(ringBuffer *queue);
haveMessage			checkMessage(ringBuffer *queue);
splitState			splitMessage(uint8_t *message, uint8_t messageSize);
uint8_t					findMessageLen(uint8_t *message);
saveQuest				saveNewQuestToList(uint8_t *newQuest);
deleteQuest			delQuestInQuestList(uint8_t *delQuestIndex);
checkList				sendQuestListToPC(questList questList);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __QUEST_ORGANIZIER_H */
