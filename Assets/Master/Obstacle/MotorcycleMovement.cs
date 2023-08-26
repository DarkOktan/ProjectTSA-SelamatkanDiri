using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleMovement : MonoBehaviour
{
	[SerializeField] public float motorCycleSpeed;

	private void FixedUpdate()
	{
		MovingMotorCycle();
	}

	private void MovingMotorCycle()
	{
		transform.Translate(-Vector2.up * motorCycleSpeed * Time.fixedDeltaTime);
	}
}
