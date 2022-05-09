#ifndef __QUEST_LIST_OBJ_H
#define __QUEST_LIST_OBJ_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

#define MAX_QUEST				0x05


typedef struct{
	uint8_t X;
	uint8_t Y;
	uint8_t Z;
}locationStruct;

typedef struct{
	locationStruct Start;
	locationStruct End;
}rotation;

typedef struct{
	rotation	questList[MAX_QUEST];
	int8_t		head;
	int8_t		tail;
	uint8_t		count;
}questList;

//questListInit
questList questListInit(questList *list);

//ringBuffEmpty
int8_t questListisEmpty(questList *list);

//ringBuffFullquestListisFull
int8_t questListisFull(questList *list);

//ringBuffGet
rotation questListGet(questList *list);

//ringBuffPush
HAL_StatusTypeDef	questListPush(questList *list, rotation newQuest);

//questListClear
HAL_StatusTypeDef questListClear(questList *list);

//questListDelItem
HAL_StatusTypeDef	questListDelItem(questList *list, uint8_t questIndex);

#ifdef __cplusplus
}
#endif

#endif /* __QUEST_LIST_OBJ_H */

