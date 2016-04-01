using UnityEngine;
using System.Collections;

public class SavePlayerPrefs : MonoBehaviour {

	private int showTutorial = 1;
	private string playerName = "nAn";
	private PlayerData playerData;

	void Awake()
	{
		if (GameObject.Find("plrName") != null)
		{
			PlayerData playerData = GameObject.Find("plrName").GetComponent<PlayerData>();
			playerName = playerData.Name;
			SavePlayerName ();
			PlayerPrefs.Save ();
			Debug.Log ("PLAYERPREFS SAVED!");
			Debug.Log (PlayerPrefs.HasKey(playerName));
		}
	}

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
