using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveData : MonoBehaviour {

    //delegate type
    public delegate void SaveMethods();

    //delegate instance
    public SaveMethods FinishedSaving;

    [SerializeField]
    private string saveURL = "http://14411.hosts.ma-cloud.nl/mythen/savescores.php";

    private List<int> dataTypeValues = new List<int>(); 

    private string plrName = "Dev Team";

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Data") != null)
        {
            PlayerData playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
            plrName = playerData.Name;
        }
    }

    public void SavePlayerScores(int _pickups, int _distance, int _time) {
        //add all scores to dataTypeValues
        dataTypeValues.Clear();
        dataTypeValues.Add(_distance);
        dataTypeValues.Add(_pickups);
        dataTypeValues.Add(_time);

        WWWForm form = new WWWForm();

        //send every dataTypeValue with a dataTypeName to the php file
        for (int i = 0; i < dataTypeValues.Count; i++)
        {
            form.AddField(DataTypes.dataTypeNames[i], dataTypeValues[i]);
        }

        form.AddField("name", plrName);

        Save(form);
    }

    public void ReplaceName(string _oldName, string _newName)
    {
        //finds an existing score with the old name, and replace it with the new name, 
        //or add an new score with zero values with the new name
        WWWForm form = new WWWForm();

        form.AddField("oldName", _oldName);
        form.AddField("newName", _newName);

        Save(form);
    }

    private void Save(WWWForm _form)
    {
        string url = saveURL;
        
        WWW www = new WWW(url, _form);

        //if done loading, send text from file to Scoreboard
        StartCoroutine(WaitForRequest(www, false));
    }

    IEnumerator WaitForRequest(WWW www, bool scoreAlreadyLoaded)
    {
        yield return www;

        FinishedSaving();
    }

    public string PlayerName
    {
        get { return plrName; }
    }

    public List<int> DataTypeValues
    {
        get { return dataTypeValues; }
    }
}
