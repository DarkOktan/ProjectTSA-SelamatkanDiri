using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using DG.Tweening;

using TMPro;

public class Main_UIController : MonoBehaviour
{
	#region Singletons
	public static Main_UIController Instance;
	#endregion

	[SerializeField]
	public Transform GameplayTransform;
	[SerializeField]
	public Transform MainMenuTransform;

	[Header("Gameplay User Interface")]
	[SerializeField]
	public TextMeshProUGUI GP_scoreText;
	[SerializeField]
	public TextMeshProUGUI GP_HighscoreText, GP_CurrentScoreText;
	[SerializeField]
	public CanvasGroup mainGameGroup;
	[SerializeField]
	public CanvasGroup gameOverGroup;


	private CanvasGroup gameplayUIGroup, mainMenuUIGroup;


	public void Awake()
	{
		Instance = this;

		gameplayUIGroup = GameplayTransform.GetComponent<CanvasGroup>();
		mainMenuUIGroup = MainMenuTransform.GetComponent<CanvasGroup>();
	}

	public void SetGameplayScoreText(int text)
	{
		GP_scoreText.text = text.ToString();
	}

	public void PlayButton()
	{
		Debug.Log("PLay Button");

		mainMenuUIGroup.DOFade(0, 0.5f).From(1);
		PlayerController.Instance.e_playerAnimator.SetInteger("Condition", 1);
		DuckMovement.instance.DuckAppear();

		GameManager.instance.IsGameOver = false;

		CameraContainer.instanceCamera.FOVTransition(5, 4, 1);
	}

	public void TurnOnGameOver()
	{
		mainGameGroup.gameObject.SetActive(false);
		gameOverGroup.gameObject.SetActive(true);

		gameOverGroup.DOFade(1, 0.5f).From(0);

		// LoadHighscore
		if (PlayerScore.m_currentScore > SaveSystem.LoadHighScore())
		{
			SaveSystem.SaveHighscore(Mathf.RoundToInt(PlayerScore.m_currentScore));
		}

		GP_CurrentScoreText.text = Mathf.RoundToInt(PlayerScore.m_currentScore).ToString();
		GP_HighscoreText.text = SaveSystem.LoadHighScore().ToString();
	}

	// Game over
	public void HomeButton()
	{
		SceneManager.LoadScene(0);
	}
	public void RetryButton()
	{
		SceneManager.LoadScene(0);
	}
}
