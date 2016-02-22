using UnityEngine;
using System.Collections;

public class SaveScores : MonoBehaviour {

    [SerializeField]
    private PlayerDistance plrDistance;

    [SerializeField]
    private PlayerDeaths plrDeaths;

    [SerializeField]
    private TimePlaying timePlaying;

    [SerializeField]
    private PlayerPickups plrPickups;

    [SerializeField]
    private ChooseScoreToLoad chooseScoreToLoad;

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
        string url = "http://14411.hosts.ma-cloud.nl/mythen/savescores.php";

        WWWForm form = new WWWForm();
        form.AddField("name", plrName);
        form.AddField("score", _distance * _pickups);
        form.AddField("pickups", _pickups);
        form.AddField("distance", _distance);
        form.AddField("time", _time);
        form.AddField("deaths", 10);

        WWW www = new WWW(url, form);

        //if done loading, send text from file to UI
        StartCoroutine(WaitForRequest(www, false));
    }

    IEnumerator WaitForRequest(WWW www, bool scoreAlreadyLoaded)
    {
        yield return www;

        chooseScoreToLoad.LoadNewScores(0);
    }
}
