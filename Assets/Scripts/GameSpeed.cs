using UnityEngine;

public class GameSpeed : MonoBehaviour {

    [SerializeField]
    private float gameSpeedIncrement = 0.001f;

    private static float startSpeed = 0.08f;

    private static float speedMultiplier = 1;

    void FixedUpdate() {
        speedMultiplier += gameSpeedIncrement;
    }

    public void SuperMode()
    {    

    }

    public static float MoveSpeed {
        //return startMoveSpeed * gameSpeed to know how fast things are moving
        get { return startSpeed * speedMultiplier; }
    }

    public static float SpeedMultiplier
    {
        //return the speed multiplier, which is incremented
        get { return speedMultiplier; }
    }
}
