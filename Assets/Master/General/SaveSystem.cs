using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveHighscore(int score)
	{
		PlayerPrefs.SetInt("Highscore", score);
		PlayerPrefs.Save();
	}

	public static int LoadHighScore()
	{
		if (PlayerPrefs.HasKey("Highscore"))
		{
			return PlayerPrefs.GetInt("Highscore");
		}

		return -1;
	}
}
