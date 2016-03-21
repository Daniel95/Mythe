using UnityEngine;
using System.Collections.Generic;

public class FinishGame : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private ScoreBoard scoreBoard;

    [SerializeField]
    private GameObject restartButton;

    public void Finish() {

        scoreBoard.gameObject.SetActive(true);
        scoreBoard.Finished();

        foreach (ScoreBase _score in scores) {
            _score.Counting = false;
        }

        restartButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
