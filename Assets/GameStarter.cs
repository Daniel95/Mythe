using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}

    public void StartGame() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
