#include "main.h"

static uint8_t 		clock[3];
questList	sList;

/**
  * @brief  is the main function that starts reading data from ringbuffer.
	* @param	sQueue, It is a temporary data structure in which data is stored.
  * @retval readRingBuffer, It is a data structure that indicates whether the data has been successfully read or not.
  */
readRingBuffer startReadRingBuffer(ringBuffer *sQueue){
	
	uint8_t buff[MAX_RING_BUFFER];
	int8_t loop = 0x00;
	uint8_t parity = 0xFF;
	uint8_t messageSize = sQueue -> count;
	
	if(checkMessage(sQueue) == MSG_IN){	
		for(loop = 0x00; loop < messageSize ; loop++){		
			buff[loop] = ringBufferGet(sQueue);		
			if(buff[loop] == MSG_END_CHAR){
				break;
			}
			if(loop > 0x01 && loop < messageSize - 0x01){		
				parity &= buff[loop];				
			}
		}
		if(buff[1] == parity){		
			if(splitMessage(buff, messageSize) == SPLIT_OK){				
				return READ_OK;				
			}
			else{				
				return READ_ERROR;				
			}
		}
		else{			
			return READ_ERROR;			
		}
	}
	else{		
		return READ_ERROR;		
	}	
}

#ifdef TEST_MODE
bool query1 = 0x00, query2 = 0x00;
#endif	/* TEST_MODE */

/**
  * @brief  Checks if there are full messages in the ringbuffer.
	* @param	sQueue, It is a temporary data structure in which data is stored.
  * @retval haveMessage, It is the data structure that indicates whether the message exists or not.
  */
haveMessage	checkMessage(ringBuffer *sQueue){
	
#ifdef TEST_MODE

	query1 = sQueue -> ringBuffer[ sQueue -> tail] == MSG_STRT_CHAR;
	query2 =  sQueue -> ringBuffer[ (sQueue -> tail + sQueue -> count - 1) % MAX_RING_BUFFER ] == MSG_END_CHAR;
	
	if(query1 && query2){

#endif	/* TEST_MODE */	
	
#ifndef		TEST_MODE
	
	if(sQueue -> ringBuffer[ sQueue -> tail] == MSG_STRT_CHAR 
		&& sQueue -> ringBuffer[ (sQueue -> tail + sQueue -> count - 1) % MAX_RING_BUFFER ] == MSG_END_CHAR){		

#endif /* TEST_MODE */	
		
			return MSG_IN;
			
	}else{	
		ringBufferClear(sQueue);
		return MSG_IN_NOT;	
	}
}

PreparationState saveState = READY_NOT;
PreparationState deltState = READY_NOT;

/**
  * @brief  is the function by which messages are fragmented.
	* @param	message[], It is the message fragment read from ringbuffer.
	*	@param 	messageSize, It is length the message fragment.
  * @retval haveMessage, It is the data structure that indicates whether the message is fragmented or not.
  */
splitState splitMessage(uint8_t message[], uint8_t messageSize){
	
	uint8_t	messageMode = 0x00;
	uint8_t loop = 0x00;
	uint8_t count = 0x00;
	
	messageMode = message[3];	

 	if(messageMode == OPEN_CHAR){			
		for(loop = 0x00; loop < messageSize; loop++){			
			if(loop > 0x04 && loop < 0x08){
				
#ifdef TEST_MODE				
				sendMessagetoPC(&message[loop], 1);
				sendMessagetoPC(&clockBuff[count], 1);
#endif /* TEST */			
				
				clock[count] = message[loop]; 
				count++;			
			}				
		}			
		sendMessagetoPC((uint8_t *) OPEN_MSG, findEndofMessage((uint8_t *) OPEN_MSG));		
		return SPLIT_OK;		
	}
	else if(messageMode == SAVE_CHAR){		
		saveState = READY;
		return SPLIT_OK;	
	}else if(saveState == READY){		
		if(saveNewQuestToList(message) == SAVE_OK){
			saveState = READY_NOT;
			return SPLIT_OK;
		}else{
			saveState = READY_NOT;
			return SPLIT_ERROR;
		}
	}
	else if(messageMode == DELETE_CHAR){
		deltState = READY;
		return SPLIT_OK;	
	}
	else if( deltState == READY){
		if(delQuestInQuestList(message) == DEL_OK){
			deltState = READY_NOT;
			return SPLIT_OK;
		}else{
			deltState = READY_NOT;
			return SPLIT_ERROR;
		}
	}
	else if(messageMode == LIST_CHAR){	
		if(sendQuestListToPC(sList) == CHECKED){
			return SPLIT_OK;
		}
		return SPLIT_ERROR;	
	}else{		
		return SPLIT_ERROR;	
	}	
}

/**
  * @brief  It is the function that allows the incoming message to be saved in the quest list.
	* @param	newQuest, It is the message fragment that stores the new task data.
  * @retval saveQuest, It is the data structure that indicates whether the quest is save or not.
  */
saveQuest saveNewQuestToList(uint8_t *newQuest){
	
	//uint8_t loop = 0x00;
	rotation buff = {0};
	saveQuest saveState = SAVE_ERR;
	
	buff.Start.X = newQuest[2];
	buff.Start.Y = newQuest[3];
	buff.Start.Z = newQuest[4];
	buff.End.X = newQuest[5];
	buff.End.Y = newQuest[6];
	buff.End.Z = newQuest[7];
	
	if(questListPush(&sList, buff) == HAL_OK) saveState = SAVE_OK;

#ifdef TEST_MODE
	sendMessagetoPC(newQuest, findEndofMessage(newQuest));
#endif /* TEST_MODE */
	
	if(saveState == SAVE_OK){
		sendMessagetoPC((uint8_t *) SAVE_OK_MSG, findEndofMessage((uint8_t *) SAVE_OK_MSG));
	}else{
		sendMessagetoPC((uint8_t *) SAVE_ERR_MSG, findEndofMessage((uint8_t *) SAVE_ERR_MSG));
	}
	return saveState;
}

/**
  * @brief  It is the function that allows the incoming message to be delete in the quest list.
	* @param	delQuestIndex, This is the message fragment that specifies the index of the task to be deleted.
  * @retval saveQuest, It is the data structure that indicates whether the quest is delete or not.
  */
deleteQuest	delQuestInQuestList(uint8_t *delQuestIndex){

	uint8_t delIndex = delQuestIndex[2];
	
	if(questListDelItem(&sList, delIndex) == HAL_OK) {		
		sendMessagetoPC((uint8_t *)DEL_OK_MSG, findEndofMessage((uint8_t *) DEL_OK_MSG));		
		return DEL_OK;	
	}
	else{		
		sendMessagetoPC((uint8_t *)DEL_ERR_MSG, findEndofMessage((uint8_t *) DEL_ERR_MSG));		
		return DEL_ERR;		
	}	
}

/**
  * @brief  It is the function that sends the task list to the PC.
	* @param	questList, is the data type that stores the task list.
  * @retval checkList, It is the data structure that indicates whether the quest is check or not.
  */
checkList	sendQuestListToPC(questList questList){
	
	uint8_t message[MAX_MSG_LEN];
	checkList checkState = CHECK_NOT;
	
	if(!questListisEmpty(&questList)){		
		if(sendMessagetoPC((uint8_t *) QUEST_LST_MSG, findEndofMessage((uint8_t *) QUEST_LST_MSG)) == HAL_OK) checkState = CHECKED;
		else return CHECK_NOT;		
		for(int8_t loop = 0; loop < questList.count ; loop++){		
				if(loop < questList.count - 1){			
					sprintf((char *)message, QUEST_MSG,questList.questList[loop].Start.X,questList.questList[loop].Start.Y,questList.questList[loop].Start.Z,questList.questList[loop].End.X,questList.questList[loop].End.Y,questList.questList[loop].End.Z);
				}else{
					sprintf((char *)message, QUEST_MSG_END,questList.questList[loop].Start.X,questList.questList[loop].Start.Y,questList.questList[loop].Start.Z,questList.questList[loop].End.X,questList.questList[loop].End.Y,questList.questList[loop].End.Z);
				}				
				if(sendMessagetoPC(message, findEndofMessage(message)) == HAL_OK) checkState = CHECKED;
				else	return CHECK_NOT;
			}		
	}else {
		if(sendMessagetoPC((uint8_t *) QUEST_LST_EMPTY_MSG, findEndofMessage((uint8_t *) QUEST_LST_EMPTY_MSG)) == HAL_OK) checkState = CHECKED;
		else return CHECK_NOT;
	}	
	return checkState;

}
