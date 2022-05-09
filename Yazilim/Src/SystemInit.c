#include "main.h"

void system_init(void){
	
	GPIO_pin_init();
	
#ifdef UART
	
	UART_init();
	
#endif /* UART */

#ifdef I2C
	
	I2C_init();
	
#endif /* I2C */

#ifdef TIM
	
	TIM_init();
	
#endif /* TIM */

#ifdef PWM
	
	PWM_init();
	
#endif /* PWM */
}

static void GPIO_pin_init(void){
	
#ifdef PORT_A
	
	__HAL_RCC_GPIOA_CLK_ENABLE();
	
#endif /* PORT_A */

#ifdef PORT_B
	
	__HAL_RCC_GPIOB_CLK_ENABLE();
	
#endif /* PORT_B */

#ifdef PORT_C
	
	__HAL_RCC_GPIOC_CLK_ENABLE();
	
#endif /* PORT_C */

#ifdef PORT_D
	
	__HAL_RCC_GPIOD_CLK_ENABLE();
	
#endif /* PORT_D */
	
#ifdef PORT_E
	
	__HAL_RCC_GPIOE_CLK_ENABLE();
	
#endif /* PORT_E */
	
	GPIO_InitTypeDef Pin_Init = {0};
	
	HAL_GPIO_WritePin(GPIOD, GREEN_LED | ORANGE_LED | RED_LED | BLUE_LED, GPIO_PIN_RESET);
	
	Pin_Init.Pin = GREEN_LED | ORANGE_LED | RED_LED | BLUE_LED;
	Pin_Init.Mode = GPIO_MODE_OUTPUT_PP;
	Pin_Init.Pull = GPIO_PULLDOWN;
	Pin_Init.Speed = GPIO_SPEED_FAST;
	HAL_GPIO_Init(GPIOD, &Pin_Init);
	
#ifdef UART
	
	HAL_GPIO_WritePin(GPIOD, USART_RX | USART_TX, GPIO_PIN_RESET);
	
	Pin_Init.Pin 				= USART_RX | USART_TX;
	Pin_Init.Mode 			= GPIO_MODE_AF_PP;
	Pin_Init.Pull 			= GPIO_PULLDOWN;
	Pin_Init.Alternate	= GPIO_AF7_USART2;
	Pin_Init.Speed 			= GPIO_SPEED_HIGH;
	HAL_GPIO_Init(GPIOA, &Pin_Init);
	
#endif /* UART */

#ifdef I2C
#endif /* I2C */
	
}

#ifdef UART

extern uint8_t  sIncomingMessage;
UART_HandleTypeDef UART_Init;

static void UART_init(void){
	
	__HAL_RCC_USART2_CLK_ENABLE();
	
	UART_Init.Instance						= UART_SLC;
	UART_Init.Init.BaudRate 			= UART_BAUDRATE;
	UART_Init.Init.WordLength 		= UART_WORDLENGTH_8B;
	UART_Init.Init.StopBits 			= UART_STOPBITS_1;
	UART_Init.Init.Parity					=	UART_PARITY_NONE;
	UART_Init.Init.Mode						=	UART_MODE_TX_RX;
	UART_Init.Init.HwFlowCtl			=	UART_HWCONTROL_NONE;
	UART_Init.Init.OverSampling		=	UART_OVERSAMPLING_16;
	
	while(HAL_UART_Init(&UART_Init) != HAL_OK);
	
#ifdef UART_IT
	
	HAL_NVIC_SetPriority(USART2_IRQn, 0, 0);
	HAL_NVIC_EnableIRQ(USART2_IRQn);
	HAL_UART_Receive_IT(&UART_Init, &sIncomingMessage, MAX_UART_RECIVE_SIZE);
	
#endif /* UART_IT */
}
#endif /* UART */

#ifdef I2C
static void I2C_init(void){

}
#endif /* I2C */

#ifdef TIM

TIM_HandleTypeDef	Message_TIM_Init = {0};
TIM_HandleTypeDef	Quest_TIM_Init = {0};

static void TIM_init(void){

	__HAL_RCC_TIM2_CLK_ENABLE();
	__HAL_RCC_TIM3_CLK_ENABLE();
	
	Message_TIM_Init.Instance 				=	MESSAGE_CHECK_TIM_SLC;
	Message_TIM_Init.Init.Prescaler		=	MESSAGE_CHECK_TIM_PRSCL;
	Message_TIM_Init.Init.CounterMode	=	TIM_COUNTERMODE_UP;
	Message_TIM_Init.Init.Period			=	MESSAGE_CHECK_TIM_PRD;
	
	Quest_TIM_Init.Instance						= QUEST_CHECK_TIM_SLC;
	Quest_TIM_Init.Init.Prescaler			=	QUEST_CHECK_TIM_PRSCL;
	Quest_TIM_Init.Init.CounterMode		=	TIM_COUNTERMODE_UP;
	Quest_TIM_Init.Init.Period				=	QUEST_CHECK_TIM_PRD;
	
	while(HAL_TIM_Base_Init(&Message_TIM_Init) != HAL_OK);
	while(HAL_TIM_Base_Init(&Quest_TIM_Init)	!= HAL_OK);
	
#ifdef TIM_IT
	
	HAL_TIM_Base_Start_IT(&Message_TIM_Init);
	HAL_NVIC_SetPriority(TIM2_IRQn, 0, 1);
	HAL_NVIC_EnableIRQ(TIM2_IRQn);
	
	HAL_TIM_Base_Start_IT(&Quest_TIM_Init);
	HAL_NVIC_SetPriority(TIM3_IRQn, 0, 2);
	HAL_NVIC_EnableIRQ(TIM3_IRQn);
	
#endif

	HAL_TIM_Base_Start(&Message_TIM_Init);
	HAL_TIM_Base_Start(&Quest_TIM_Init);
	
}
#endif /* TIM */

#ifdef PWM

TIM_HandleTypeDef	PWM_TIM_Init = {0};

static void PWM_init(void){

	__HAL_RCC_TIM8_CLK_ENABLE();
	
	TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};
  TIM_BreakDeadTimeConfigTypeDef sBreakDeadTimeConfig = {0};

  PWM_TIM_Init.Instance = TIM8;
  PWM_TIM_Init.Init.Prescaler = 125;
  PWM_TIM_Init.Init.CounterMode = TIM_COUNTERMODE_UP;
  PWM_TIM_Init.Init.Period = 2560;
  PWM_TIM_Init.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  PWM_TIM_Init.Init.RepetitionCounter = 0;
  if (HAL_TIM_Base_Init(&PWM_TIM_Init) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&PWM_TIM_Init, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&PWM_TIM_Init) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&PWM_TIM_Init, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCNPolarity = TIM_OCNPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  sConfigOC.OCIdleState = TIM_OCIDLESTATE_RESET;
  sConfigOC.OCNIdleState = TIM_OCNIDLESTATE_RESET;
  if (HAL_TIM_PWM_ConfigChannel(&PWM_TIM_Init, &sConfigOC, TIM_CHANNEL_1) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&PWM_TIM_Init, &sConfigOC, TIM_CHANNEL_2) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&PWM_TIM_Init, &sConfigOC, TIM_CHANNEL_3) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&PWM_TIM_Init, &sConfigOC, TIM_CHANNEL_4) != HAL_OK)
  {
    Error_Handler();
  }
  sBreakDeadTimeConfig.OffStateRunMode = TIM_OSSR_DISABLE;
  sBreakDeadTimeConfig.OffStateIDLEMode = TIM_OSSI_DISABLE;
  sBreakDeadTimeConfig.LockLevel = TIM_LOCKLEVEL_OFF;
  sBreakDeadTimeConfig.DeadTime = 0;
  sBreakDeadTimeConfig.BreakState = TIM_BREAK_DISABLE;
  sBreakDeadTimeConfig.BreakPolarity = TIM_BREAKPOLARITY_HIGH;
  sBreakDeadTimeConfig.AutomaticOutput = TIM_AUTOMATICOUTPUT_DISABLE;
  if (HAL_TIMEx_ConfigBreakDeadTime(&PWM_TIM_Init, &sBreakDeadTimeConfig) != HAL_OK)
  {
    Error_Handler();
  }
  PWM_PIN_init();
	PWM_Start();
	
}

static void PWM_PIN_init(void){
	
	GPIO_InitTypeDef GPIO_InitStruct = {0};
	
	GPIO_InitStruct.Pin = GPIO_PIN_6|GPIO_PIN_7|GPIO_PIN_8|GPIO_PIN_9;
	GPIO_InitStruct.Mode = GPIO_MODE_AF_PP;
	GPIO_InitStruct.Pull = GPIO_NOPULL;
	GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
	GPIO_InitStruct.Alternate = GPIO_AF3_TIM8;
	HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);
	
}

static void PWM_Start(void){
	
	HAL_TIM_PWM_Start(&PWM_TIM_Init, TIM_CHANNEL_1);
	HAL_TIM_PWM_Start(&PWM_TIM_Init, TIM_CHANNEL_2);
	HAL_TIM_PWM_Start(&PWM_TIM_Init, TIM_CHANNEL_3);
	HAL_TIM_PWM_Start(&PWM_TIM_Init, TIM_CHANNEL_4);
	
}

#endif /* PWM */
