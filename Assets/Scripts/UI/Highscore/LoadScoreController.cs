using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadScoreController : MonoBehaviour {

    [SerializeField]
    private LoadData loadData;

    [SerializeField]
    private ScoreBoard scoreBoard;

    [SerializeField]
    private List<string> scoreNames;

    [SerializeField]
    private int scoresNamesIndex;

    [SerializeField]
    private bool loadScoresOnStart;

    [SerializeField]
    private GameObject loadingIcon;

    private Text textField;

    void Start() {
        textField = transform.Find("Text").GetComponent<Text>();
        if(loadScoresOnStart) LoadScoreType(0);
        loadScoresOnStart = false;
        loadingIcon.SetActive(false);
    }

    void OnEnable()
    {
        loadData.FinishedLoading += DoneLoading;
    }

    void OnDisable()
    {
        loadData.FinishedLoading -= DoneLoading;
    }

    public void LoadScoreType(int _change) {

        //decrement or increment the index of the list
        scoresNamesIndex += _change;

        //if the index is now higher then the list count or lower then zero, change it
        if (scoresNamesIndex < 0) scoresNamesIndex = scoreNames.Count - 1;
        else if (scoresNamesIndex >= scoreNames.Count) scoresNamesIndex = 0;

        //edit the text value to the new score we are going to load
        textField.text = (scoreNames[scoresNamesIndex]);

        loadingIcon.SetActive(true);

        //load the new score
        //we changed the score type, now load it
        loadData.Load(scoreNames[scoresNamesIndex]);
    }

    void DoneLoading(string _data, string _dataType) {
        loadingIcon.SetActive(false);

        scoreBoard.NewScoreBoard(_data, _dataType);

        //get the players ranking
        scoreBoard.GetPlayerRanking(_data);
    }
}
