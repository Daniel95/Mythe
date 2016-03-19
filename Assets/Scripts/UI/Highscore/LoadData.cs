using UnityEngine;
using System.Collections;

public class LoadData : MonoBehaviour {

    //delegate type
    public delegate void LoadDataMethods(string stringVar, string stringVar2);

    //delegate instance
    public LoadDataMethods FinishedLoading;

    [SerializeField]
    private string dataFieldName = "scoreType";

    [SerializeField]
    private GameObject NoConnectionImage;

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
        form.AddField(dataFieldName, _scoreType);

        WWW www = new WWW(url, form);

        //if done loading, send text from file to UI
        StartCoroutine(WaitForRequest(www, _scoreType));
    }

    IEnumerator WaitForRequest(WWW _www, string _scoreType)
    {
        yield return _www;

        if (_www.text == "")
        {
            NoConnectionImage.SetActive(true);
        } else {
            NoConnectionImage.SetActive(false);

            if (FinishedLoading == null) print("is null");

            //sends the score results to scoreBoard script
            FinishedLoading(_www.text, _scoreType);
        }
    }
}
