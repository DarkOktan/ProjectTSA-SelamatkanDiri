using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMotor : MonoBehaviour
{
	[SerializeField]
	public float horizontalStepTime = 0.1f;
	[SerializeField]
	public Vector2 minMaxXPos;

	private float InputX;

	private Vector2 defaultPosition, currentPosition, targetPosition;

	private void Awake()
	{
		currentPosition = transform.localPosition;
		targetPosition = transform.localPosition;
	}

	private void Update()
	{
		if (GameManager.instance.IsGameOver) return;

		HorizontalMovement();
	}

	public void SetInputX(Vector2 input)
	{
		InputX = input.x;

		// Set Target and currentPosition
		targetPosition = currentPosition + Vector2.right * (InputX * 1.25f);
		targetPosition = new Vector2(Mathf.Clamp(targetPosition.x, minMaxXPos.x, minMaxXPos.y), currentPosition.y);

		currentPosition = targetPosition;
	}
	public void HorizontalMovement()
	{
		transform.localPosition = Vector3.MoveTowards(transform.position, targetPosition, horizontalStepTime);
	}
}
