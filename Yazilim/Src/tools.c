#include "main.h"

//uint8_t buff[2];
//
//uint8_t encodingMessageByte(uint8_t messagePiece){
//	
//	buff[0] = messagePiece & 0xFF;
//	buff[1] = (messagePiece >> 0x04) * 0x0A;
//	
//	return buff[1] + buff[0];
//	
//}

/**
  * @brief  Function to find message length.
	* @param	messagePiece, It is message.
  * @retval loop + 1, It is length the message.
  */
uint8_t	findEndofMessage(uint8_t *messagePiece){
	
	uint8_t loop = 0x00;
	
/* Find message length --------------------------------------------*/	
	for(loop = 0x00; loop < MAX_MSG_LEN; loop++){
		if(messagePiece[loop] == MSG_END_CHAR || messagePiece[loop] == QUEST_SPLIT_CHAR){
			break;
		}
	}
	return loop + 1;
}
