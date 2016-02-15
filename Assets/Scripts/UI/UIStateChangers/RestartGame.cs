using UnityEngine;
using System.Collections.Generic;

public class RestartGame : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private GameObject scoreBoard;

    [SerializeField]
    private GameObject finishButton;

    void Start() {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        scoreBoard.SetActive(false);

        foreach (ScoreBase _score in scores)
        {
            _score.Counting = true;
            _score.ResetValue();
        }

        finishButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
