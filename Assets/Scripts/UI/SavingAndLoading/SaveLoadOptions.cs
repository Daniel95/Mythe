using UnityEngine;
using System.Collections;

public class SaveLoadOptions : MonoBehaviour {

    private OptionsData optionsData;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>())
        {
            optionsData = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>();
            RetrieveSavedOptionsData();
        }
    }

    public void RetrieveSavedOptionsData()
    {
        if (PlayerPrefs.HasKey("EnableCursor"))
            optionsData.EnableCursor = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableCursor"));
        if (PlayerPrefs.HasKey("EnableVibration"))
            optionsData.EnableVibration = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableVibration"));
        if (PlayerPrefs.HasKey("EnableTutorial"))
            optionsData.EnableTutorial = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableTutorial"));
        if (PlayerPrefs.HasKey("EnableMusic"))
        {
            optionsData.EnableTutorial = System.Convert.ToBoolean(PlayerPrefs.GetInt("EnableMusic"));
        }
            
    }

    public void SavePref(string _dataName, int _dataValue)
    {
        print("save");
        PlayerPrefs.SetInt(_dataName, _dataValue);
        PlayerPrefs.Save();
    }
}
