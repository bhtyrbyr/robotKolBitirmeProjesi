#include "main.h"


extern TIM_HandleTypeDef	PWM_TIM_Init;

static servoMotorsState instantAngle;
static servoMotorsState targetAngle;
static float sLastBias = 0;
static float sIntegralBias = 0;

static int16_t calculateDutyCycle(int16_t angle);
static int16_t PIDController(int16_t targetAnlge, int16_t instantAngle);

/**
  * @brief  Function to moves the servo motor.
	* @param	angle, These are the angle values at wich the servo motors will be positioned.
  * @retval HAL_StatusTypeDef, Indicates the end of transection.
  */
HAL_StatusTypeDef runServoMotor(servoMotorsState *angle){

	int8_t loop = 0;

	/* Find dutycycle value for angle value------------------------------------------------------*/
	targetAngle.servo1Angle = calculateDutyCycle(angle -> servo1Angle);
	targetAngle.servo2Angle = calculateDutyCycle(angle -> servo2Angle);
	targetAngle.servo3Angle = calculateDutyCycle(angle -> servo3Angle);
	
	/* PID control-------------------------------------------------------------------------------*/
	for(loop = 0; loop > -1; loop++){
		
		if((instantAngle.servo1Angle == targetAngle.servo1Angle) && 
			(instantAngle.servo2Angle == targetAngle.servo2Angle) && 
		(instantAngle.servo2Angle == targetAngle.servo3Angle))
		{
			break;
		}else{
		
			instantAngle.servo1Angle = PIDController(targetAngle.servo1Angle, instantAngle.servo1Angle);
			instantAngle.servo2Angle = PIDController(targetAngle.servo2Angle, instantAngle.servo2Angle);
			instantAngle.servo3Angle = PIDController(targetAngle.servo3Angle, instantAngle.servo3Angle);
			
			if((instantAngle.servo1Angle > targetAngle.servo1Angle) && 
				(instantAngle.servo2Angle > targetAngle.servo2Angle) && 
			(instantAngle.servo2Angle > targetAngle.servo3Angle))
			{
				instantAngle.servo1Angle = targetAngle.servo1Angle;
				instantAngle.servo2Angle = targetAngle.servo2Angle;
				instantAngle.servo3Angle = targetAngle.servo3Angle;
			}
	/* Set dutyCycle-------------------------------------------------------------------------------*/		
			PWM_TIM_Init.Instance -> CCR1 = instantAngle.servo1Angle;
			PWM_TIM_Init.Instance -> CCR2 = instantAngle.servo2Angle;
			PWM_TIM_Init.Instance -> CCR3 = instantAngle.servo3Angle;
			
		}
	}
	return HAL_OK;
}

/**
  * @brief  Function to calculates dutyCycle for the current angle value.
	* @param	angle, These are the angle values at wich the servo motors will be positioned.
  * @retval buff, Calculated dutyCycle value.
  */
int16_t calculateDutyCycle(int16_t angle){
	
	float buff = (float)angle;
	
	/**
		*	calculation for dutycycle;
		*	
		*	Servo motor must be able to work ont the PWM frequency is 50Hz.
		*
		*	Microcontroller operating frequency = 16 MHz
		*
		*	IF TIM8's prescaler is set to 125, calculation of TIM8's period;
		*		
		*	50Hz = (Microcontroller operating frequency / TIM8 prescaler) / TIM8 period
		*	50Hz = (16.000.000Hz / 125) / TIM8's period
		*	50Hz = 128.000Hz / TIM8's period
		*
		*		The period of TIM8 is found to be 2560.	This value is the maximum dutycycle value.
		*	In order for the servo motor to work between 0 - 180 degrees, min 2.3%, max 12% logic 
		*	1 must be applied in one period of the PWM signal.
		*
		*	In the case, the dutycycle value is;
		*
		*	min = 2560 / 100 * 2.3	= 60,
		*	max = 2560 / 100 * 12		=	305 
		*
		*	Difference between minimum and maximum value = 305 - 60 = 245,
		*
		*	The formula that calculates the dutycycle according to the given angle value;
		*
		*	dutycycle = min_dutycycle_value + ( max_dutycycle_value * ( angle_value / 180)) 
		*	
		**/
	
	buff = 60 + (float)( 245 * (float)(buff /180));
	
	return buff;

}

/**
  * @brief  PID control function for servo motor movement.
	* @param	targetAnlge, Target angle value.
	* @param	instantAngle, anlik angle value.
  * @retval pwm, Calculated dutyCycle value.
  */
int16_t PIDController(int16_t targetAnlge, int16_t instantAngle){

	int16_t bias, pwm;
	
	bias = targetAnlge - instantAngle;
	sIntegralBias += bias;
	pwm = KP * bias + KI * sIntegralBias + KD * (bias - sLastBias);
	sLastBias = bias;
	
	return pwm;
	
}

/**
  * @brief  Function for holding or releasing.
	* @param	state, holding or releasing state.
  * @retval HAL_StatusTypeDef, Indicates the end of function.
  */
HAL_StatusTypeDef holdOrRelease(handleState state){

	if(state == HOLD){		
		PWM_TIM_Init.Instance -> CCR4 = calculateDutyCycle(HOLD_ANGLE);
		return HAL_OK;		
	}else if(state == RELEASE){		
		PWM_TIM_Init.Instance -> CCR4 = calculateDutyCycle(RELEASE_ANGLE);
		return HAL_OK;
	}
	return HAL_ERROR;
	
}
