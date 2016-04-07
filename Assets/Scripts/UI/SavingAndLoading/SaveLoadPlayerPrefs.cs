using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveLoadPlayerPrefs : MonoBehaviour {

    //delegate type
    public delegate void PlayerNameExists(string _playerName);

    //delegate type
    public delegate void PlayerNameDoesntExist();

    //delegate instance
    public PlayerNameExists LoadedPlayerName;

    public PlayerNameDoesntExist NoPlayerNameFound;

    private int showTutorial = 1;

    private OptionsData optionsData;

    void Start()
	{
        //check if we are changing our name from the option menu
        if (GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>()) {
            optionsData = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>();

            RetrieveSavedOptionsData();

            if (optionsData.CheckIfChangingName())
                NoPlayerNameFound();
            else
                CheckPlayerName();
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

	public void SavePref(string _dataName, int _dataValue)
	{
		PlayerPrefs.SetInt (_dataName, _dataValue);
        PlayerPrefs.Save();
    }

    public void SavePlayerName(string _playerName)
    {
        PlayerPrefs.SetString("PlayerName", _playerName);
        PlayerPrefs.Save();
    }

    public void RetrieveSavedOptionsData() {
        if (PlayerPrefs.HasKey("EnableCursor"))
            optionsData.EnableCursor = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableCursor"));
        if (PlayerPrefs.HasKey("EnableVibration"))
            optionsData.EnableVibration = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableVibration"));
        if (PlayerPrefs.HasKey("EnableTutorial"))
            optionsData.EnableTutorial = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableTutorial"));
    }

    private void CheckPlayerName() {
        //if the playername is already saved, send the saved playername to playerData. 
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            if (LoadedPlayerName != null)
                LoadedPlayerName(PlayerPrefs.GetString("PlayerName"));
        }
        else
        { //else, let the player type his name so we can save it for next time
            if (NoPlayerNameFound != null)
                NoPlayerNameFound();
        }
    }

    public void DeletePlayerPref(string _playerPref) {
        //delete the existing player pref
        PlayerPrefs.DeleteKey(_playerPref);
    }
}
