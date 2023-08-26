using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static float m_currentScore;

	private float targetScoreToSpeedUp = 100;
	private bool alreadySpeedUp;

	public void Awake()
	{
		m_currentScore = 0;
	}

	private void Update()
	{
		if (GameManager.instance.IsGameOver) return;

		UpdateScore();
	}

	private void UpdateScore()
	{
		m_currentScore += Time.deltaTime * GameManager.instance.environmentMovement.environmentMoveSpeed;

		CheckScore();

		Main_UIController.Instance.SetGameplayScoreText(Mathf.RoundToInt(m_currentScore));
	}

	private void CheckScore()
	{
		if (Mathf.RoundToInt(m_currentScore) % targetScoreToSpeedUp == 3)
		{
			alreadySpeedUp = false;
		}

		if (m_currentScore <= 0 || alreadySpeedUp) return;

		
		if (Mathf.RoundToInt(m_currentScore) % targetScoreToSpeedUp == 0)
		{
			GameManager.instance.environmentMovement.ChangeEnvironmentSpeed(GameManager.instance.environmentMovement.environmentMoveSpeed + 1);
			alreadySpeedUp = true;
		}
	}
}
