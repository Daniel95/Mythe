using UnityEngine;
using System.Collections.Generic;

public class FinishGameController : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private SaveData saveScores;

    [SerializeField]
    private GameObject gameoverScreen;

    [SerializeField]
    private LoadScoreController loadScoreController;

    void OnEnable()
    {
        saveScores.FinishedSaving += DoneSaving;
    }

    void OnDisable()
    {
        saveScores.FinishedSaving -= DoneSaving;
    }

    public void Finish() {

        foreach (ScoreBase _score in scores) {
            _score.Counting = false;
        }

        //Handheld.Vibrate();

        gameoverScreen.SetActive(true);

        saveScores.SavePlayerScores();
    }

    void DoneSaving() {
        loadScoreController.LoadScoreType(0);
    }
}
