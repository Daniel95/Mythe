using UnityEngine;
using System.Collections.Generic;

public class FinishGameController : MonoBehaviour {

    [SerializeField]
    private List<ScoreBase> scores;

    [SerializeField]
    private GameObject healthBar;

    [SerializeField]
    private SaveData saveScores;

    [SerializeField]
    private GameObject gameoverScreen;

    [SerializeField]
    private LoadScoreController loadScoreController;

	[SerializeField]
	private GameObject pauseButton;

	[SerializeField]
	private GameObject distanceIcon;

    [SerializeField]
    private PlayerDistance plrDistance;

    [SerializeField]
    private PlayerDeaths plrDeaths;

    [SerializeField]
    private TimePlaying timePlaying;

    [SerializeField]
    private PlayerPickups plrPickups;

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
        healthBar.SetActive(false);
		pauseButton.SetActive (false);
		distanceIcon.SetActive (false);

        saveScores.SavePlayerScores(plrPickups.Pickups, plrDistance.Distance, timePlaying.TimeInt());
    }

    void DoneSaving() {
        loadScoreController.LoadScoreType(0);
    }
}
