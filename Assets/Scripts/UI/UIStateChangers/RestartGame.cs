using UnityEngine;
using System.Collections.Generic;

public class RestartGame : MonoBehaviour {

    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private GameSpeed gameSpeed;



    public void Restart()
    {
        sceneLoader.loadNewScene("Game");

        /*
        //reset every score, and continue counting score
        foreach (ScoreBase _score in scores)
        {
            _score.ResetValue();
            _score.Counting = true;
        }

        healthBar.Restart();

        gameSpeed.Reset();

        gameOverScreen.SetActive(false);
        */
    }
}
