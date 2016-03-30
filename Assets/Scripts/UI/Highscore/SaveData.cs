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

    [SerializeField]
    private List<int> dataTypeValues = new List<int>(); 

    [SerializeField]
    private PlayerDistance plrDistance;

    [SerializeField]
    private PlayerDeaths plrDeaths;

    [SerializeField]
    private TimePlaying timePlaying;

    [SerializeField]
    private PlayerPickups plrPickups;

    [SerializeField]
    private LoadScoreController chooseScoreToLoad;

    private string plrName = "Anonymous";

    private string plrId = "TestId";

    void Awake()
    {
        if (GameObject.Find("plrName") != null)
        {
            PlayerData playerData = GameObject.Find("plrName").GetComponent<PlayerData>();
            plrName = playerData.Name;
            plrId = playerData.Id;
        }
    }

    public void SavePlayerScores()
    {
        Save(plrPickups.Pickups, plrDistance.Distance, timePlaying.TimeInt());
    }

    private void Save(int _pickups, int _distance, int _time)
    {
        string url = saveURL;

        //add all scores to dataTypeValues
        dataTypeValues.Clear();
        dataTypeValues.Add(_distance);
        dataTypeValues.Add(_pickups);
        dataTypeValues.Add(_time);
        dataTypeValues.Add(10);

        WWWForm form = new WWWForm();

        form.AddField("name", plrName);
        form.AddField("deviceId", plrId);

        //send every dataTypeValue with a dataTypeName to the php file
        for (int i = 0; i < DataTypes.dataTypeNames.Length; i++) {
            form.AddField(DataTypes.dataTypeNames[i], dataTypeValues[i]);
        }
        
        WWW www = new WWW(url, form);

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
