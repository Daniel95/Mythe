using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChooseScoreToLoad : MonoBehaviour {

    [SerializeField]
    private LoadScores loadScores;

    [SerializeField]
    private List<string> scoreNames;

    [SerializeField]
    private int scoresNamesIndex;

    [SerializeField]
    private bool loadScoresOnStart;

    private Text textField;

    void Start() {
        textField = transform.Find("Text").GetComponent<Text>();
        if(loadScoresOnStart) LoadNewScores(0);
    }

    public void LoadNewScores(int _change) {

        //decrement or increment the index of the list
        scoresNamesIndex += _change;

        //if the index is now higher then the list count or lower then zero, change it
        if (scoresNamesIndex < 0) scoresNamesIndex = scoreNames.Count - 1;
        else if (scoresNamesIndex >= scoreNames.Count) scoresNamesIndex = 0;

        //edit the text value to the new score we are going to load
        textField.text = (scoreNames[scoresNamesIndex]);

        //load the new score
        loadScores.Load(scoreNames[scoresNamesIndex]);
    }
}
