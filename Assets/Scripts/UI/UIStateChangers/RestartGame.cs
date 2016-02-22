using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RestartGame : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private HealthBar healthBar;

    public void Restart()
    {
        //reset every score, and continue counting score
        foreach (ScoreBase _score in scores)
        {
            _score.ResetValue();
            _score.Counting = true;
        }

        healthBar.Restart();

        gameOverScreen.SetActive(false);
    }
}
