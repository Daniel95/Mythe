using UnityEngine;
using System.Collections;

public class SavePlayerPrefs : MonoBehaviour {

	private int showTutorial = 1;
	private string playerName = "PussyDestoyer420";


	public void SaveTutorialSettings()
	{
		PlayerPrefs.SetInt("ShowTutorial", showTutorial);
	}

	public void LoadTutorialSettings()
	{
		showTutorial = PlayerPrefs.GetInt("ShowTutorial");
	}

	public void SavePlayerName()
	{
		PlayerPrefs.SetString ("PlayerName", playerName);
	}

	public void LoadPlayerName()
	{
		playerName = PlayerPrefs.GetString ("PlayerName");
	}
}
