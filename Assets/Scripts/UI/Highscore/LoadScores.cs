using UnityEngine;
using System.Collections;

public class LoadScores : MonoBehaviour {

    [SerializeField]
    private GameObject noConnectionImage;

    private ScoreBoard board;

    void Awake()
    {
        board = GetComponent<ScoreBoard>();
    }

    public void Load(string _scoreType)
    {
        //the locations of the php file
        string url = "http://14411.hosts.ma-cloud.nl/mythen/getscores.php";

        WWWForm form = new WWWForm();

        //give the scoreType to the php file, under the name scoreType
        form.AddField("scoreType", _scoreType);

        WWW www = new WWW(url, form);

        //if done loading, send text from file to UI
        StartCoroutine(WaitForRequest(www, _scoreType));
    }

    IEnumerator WaitForRequest(WWW _www, string _scoreType)
    {
        yield return _www;

        //sends the score results to scoreBoard script
        if (_www.text == "")
        {
            noConnectionImage.SetActive(true);
        }
        else
        {
            noConnectionImage.SetActive(false);
            board.MakeABoard(_www.text, _scoreType);
        }
    }
}
