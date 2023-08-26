using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField] public float environmentMoveSpeed;

	private void FixedUpdate()
	{
		MovingEnvironment();
	}

	private void MovingEnvironment()
	{
		transform.Translate(-Vector2.up * environmentMoveSpeed * Time.fixedDeltaTime);
	}

	public void ChangeEnvironmentSpeedSmoothly(float targetSpeed, float transitionTime)
	{
		DOTween.To(() => environmentMoveSpeed, x => environmentMoveSpeed = x, targetSpeed, transitionTime);
	}
	public void ChangeEnvironmentSpeed(float targetSpeed)
	{
		environmentMoveSpeed = targetSpeed;
	}
}
