#include "main.h"

/**
  * @brief  Initilation the questList
	* @param	*list	=	the questList object.
  * @retval none
  */
questList questListInit(questList *list)
{
//	uint8_t loop = 0x00;
//	for(loop = 0x00; loop < sizeof(list -> questList); loop++){
//		list -> questList[loop] = 0x00;
//	}
	list -> head = 0x00;
	list -> tail = 0x00;
	list -> count = 0x00;
	return *list;
}

/**
  * @brief	Check the if the list is empty.
	* @param	*list	=	the questList object.
  * @retval if list state of empty, return 1.
  */
int8_t questListisEmpty(questList *list)
{
	return (0x00 == list -> count);
}

/**
  * @brief	Check the if the list is full.
	* @param	*list	=	the questList object.
  * @retval if list state of empty, return 1.
  */
int8_t questListisFull(questList *list)
{
	return (MAX_QUEST == list -> count);
}

/**
  * @brief	Get data in the list.
	* @param	*list	=	the questList object.
  * @retval buff		=	First data in questList.
  */
rotation questListGet(questList *list)
{
	
	rotation buffer;
	
	if(!questListisEmpty(list))
	{
		buffer = list -> questList[list -> tail];
		list -> tail = (list ->tail + 1) % MAX_QUEST;
		list -> count--;
	}
	return buffer;
}

/**
  * @brief	Push data to the list.
	* @param	*list	=	the questList object.
	*	@param	newQuest = is the data structure that stores the new quest data.
  * @retval Hal_StatusTypeDef	=	Is it correct to insert the data.
  */
HAL_StatusTypeDef	questListPush(questList *list, rotation newQuest)
{
	if(!questListisFull(list))
	{
		list -> questList[list -> head] = newQuest;
		list -> head = (list -> head + 1) % MAX_QUEST;
		list -> count++;
		return HAL_OK;
	}else{ return HAL_ERROR;}
}

/**
  * @brief	Clear all data in the list.
	* @param	*list	=	the questList object.
  * @retval Hal_StatusTypeDef	=	Has the data been cleared.
  */
HAL_StatusTypeDef questListClear(questList *list)
{
	
//	uint8_t loop = 0x00;
//	for(loop = 0x00; loop < sizeof(list -> questList); loop++){
//		list -> questList[loop] = 0x00;
//	}
	list -> head = 0x00;
	list -> tail = 0x00;
	list -> count = 0x00;
	return HAL_OK;
	
}

/**
  * @brief	Deletes the desired task from the list.
	* @param	*list	=	the questList object.
	* @param	questIndex	=	index of the task to be deleted.
  * @retval Hal_StatusTypeDef	=	Has the data been cleared.
  */
HAL_StatusTypeDef	questListDelItem(questList *list, uint8_t questIndex){

	if(!questListisEmpty(list))
	{
		uint8_t loop = 0;
		for(loop = list -> tail + questIndex; loop < list -> count; loop++){
			list -> questList[loop] = list ->questList[loop+1];
		}
		list -> head--;
		list -> count--;
		return HAL_OK;
	}else{
		return HAL_ERROR;
	}

}

