using UnityEngine;
using System.Collections.Generic;

public class FinishGame : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private SaveScores saveScores;

    [SerializeField]
    private GameObject gameoverScreen;

    public void Finish() {
        foreach (ScoreBase _score in scores) {
            _score.Counting = false;
        }

        //Handheld.Vibrate();

        gameoverScreen.SetActive(true);

        saveScores.SavePlayerScores();
    }
}
