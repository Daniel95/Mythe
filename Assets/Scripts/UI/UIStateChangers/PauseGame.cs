using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    
    
    //this class handles the timescale of the game.
    //only physics and fixedupdates are affected by this!
	public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
    }
}
