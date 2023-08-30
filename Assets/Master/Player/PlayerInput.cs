using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMotor motor;
	private PlayerCombat combat;

	private void Awake()
	{
		motor = GetComponent<PlayerMotor>();
		combat = GetComponent<PlayerCombat>();
	}

	void Update()
    {
		if (Input.anyKeyDown)
			SetInput();

		if (Input.GetKeyDown(KeyCode.Z))
		{
			combat.RantingAttack();
			PlayerController.Instance.e_playerAnimator.SetTrigger("RantingAttack");
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			// combat.KetapelAttack();
			PlayerController.Instance.e_playerAnimator.SetTrigger("KetapelAttack");
		}
    }

    private void SetInput()
	{
		Vector2 input = Vector2.zero;
		input.x = Input.GetAxisRaw("Horizontal");

		motor.SetInputX(input);
	}
}
