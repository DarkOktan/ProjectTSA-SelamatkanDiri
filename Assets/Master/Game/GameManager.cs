using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region Singletons
	public static GameManager instance;
	#endregion

	[SerializeField] public EnvironmentMovement environmentMovement;

	public bool IsGameOver;

	private void Awake()
	{
		instance = this;
		IsGameOver = true;
	}

	public void MoveEnviFirstTime()
	{
		environmentMovement.ChangeEnvironmentSpeedSmoothly(4, 0.5f);
	}

	public void GameOver()
	{
		IsGameOver = true;
		environmentMovement.ChangeEnvironmentSpeed(0);

		PlayerController.Instance.e_playerAnimator.SetInteger("Condition", 3);
		DuckMovement.instance.DuckAppearOnGameOver();

		Main_UIController.Instance.TurnOnGameOver();
	}
}
