using UnityEngine;
using System.Collections;

public class LoadScores : MonoBehaviour {

    private ScoreBoard board;

    void Awake()
    {
        board = GetComponent<ScoreBoard>();
    }

    public void Load(string _scoreType)
    {

        string url = "http://14411.hosts.ma-cloud.nl/mythen/getscores.php";

        WWWForm form = new WWWForm();
        form.AddField("scoreType", _scoreType);

        WWW www = new WWW(url, form);

        //if done loading, send text from file to UI
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        board.MakeScoreBoard(www.text);
    }
}
