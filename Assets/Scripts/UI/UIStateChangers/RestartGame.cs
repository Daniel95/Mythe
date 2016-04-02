using UnityEngine;
using System.Collections.Generic;

public class RestartGame : MonoBehaviour {

    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private GameSpeed gameSpeed;

    public void Restart()
    {
        gameSpeed.Reset();

        sceneLoader.LoadNewScene("Game");
    }
}
