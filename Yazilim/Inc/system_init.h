#ifndef __SYSTEM_INIT_H
#define __SYSTEM_INIT_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes */
#include "stm32f4xx_hal.h"
/*-----------------------*/

/* Enable Defines */
#define UART
#define UART_IT
//#define I2C
//#define I2C_IT
#define TIM
#define TIM_IT
#define PWM
/*-----------------------*/

/* Port Defines */
#define	PORT_A
//#define	PORT_B
#define	PORT_C
#define	PORT_D
//#define	PORT_E
/*-----------------------*/

/* Module Defines */
#define UART_SLC							USART2
#define UART_BAUDRATE					UART_BaudRate_state_four // 9600
#define I2C_SLC
#define MESSAGE_CHECK_TIM_SLC			TIM2
#define MESSAGE_CHECK_TIM_PRSCL		1000
#define MESSAGE_CHECK_TIM_PRD			3200
#define QUEST_CHECK_TIM_SLC				TIM3
#define QUEST_CHECK_TIM_PRSCL			1000
#define QUEST_CHECK_TIM_PRD				32
#define PWM_TIM_SLC								TIM8
#define	PWM_TIM_PRSCL							125
#define	PWM_TIM_PRD								2560
/*-----------------------*/

/* Pin Defines */
#define GREEN_LED 						GPIO_PIN_12
#define ORANGE_LED 						GPIO_PIN_13
#define RED_LED 							GPIO_PIN_14 
#define BLUE_LED 							GPIO_PIN_15

#define USART_RX							GPIO_PIN_3
#define USART_TX							GPIO_PIN_2

//#define I2C_SDA								1
//#define I2C_SCL								1

#define SERVO_MOTOR_1					GPIO_PIN_6
#define SERVO_MOTOR_2					GPIO_PIN_7
#define SERVO_MOTOR_3					GPIO_PIN_8

#define MAX_UART_RECIVE_SIZE	0x01
/*-----------------------*/

/* Variable Defines */
/*-----------------------*/

/* Function Decleration */
void system_init(void);
static void GPIO_pin_init(void);
static void UART_init(void);
static void I2C_init(void);
static void TIM_init(void);
static void PWM_init(void);
static void PWM_PIN_init(void);
static void PWM_Start(void);
/*-----------------------*/

#ifdef __cplusplus
}
#endif

#endif /* __SYSTEM_INIT_H */
