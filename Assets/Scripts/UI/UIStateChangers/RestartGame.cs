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
<<<<<<< HEAD
		gameSpeed.Reset ();

        sceneLoader.loadNewScene("Game");


=======
        sceneLoader.loadNewScene("Game");

>>>>>>> origin/Sprint-2
        /*
        //reset every score, and continue counting score
        foreach (ScoreBase _score in scores)
        {
            _score.ResetValue();
            _score.Counting = true;
        }

        healthBar.Restart();

        c

        gameOverScreen.SetActive(false);
        */
    }
}
