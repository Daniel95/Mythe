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
    private List<string> dataTypeNames = new List<string>();

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

    void Awake()
    {
        if (GameObject.Find("plrName") != null) plrName = GameObject.Find("plrName").GetComponent<PlayerName>().Name;
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

        //send every dataTypeValue with a dataTypeName to the php file
        for (int i = 0; i < dataTypeNames.Count; i++) {
            form.AddField(dataTypeNames[i], dataTypeValues[i]);
        }

        
        //form.AddField("distance", _distance);
        //form.AddField("time", _time);
        //form.AddField("deaths", 10);
        
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
    /*
    public int Distance {
        get { return plrDistance.Distance; }
    }

    public int Pickups
    {
        get { return plrPickups.Pickups; }
    }

    public int Time
    {
        get { return timePlaying.TimeInt(); }
    }

    public int Deaths
    {
        get { return plrDeaths.Deaths; }
    }*/

    public List<string> DataTypeNames {
        get { return dataTypeNames; }
    }

    public List<int> DataTypeValues
    {
        get { return dataTypeValues; }
    }
}
