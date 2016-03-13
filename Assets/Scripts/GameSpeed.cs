using UnityEngine;

public class GameSpeed : MonoBehaviour {

    [SerializeField]
    private float gameSpeedIncrement = 0.00015f;

    [SerializeField]
    private float startSpeed = 0.05f;

    private static float speed;

    private static float speedMultiplier = 1;

    void Start() {
        speed = startSpeed;
    }

    void FixedUpdate() {
        speedMultiplier += gameSpeedIncrement;
    }

    public void SuperMode()
    {    

    }

    public void Reset()
    {
        speedMultiplier = 1;
        startSpeed = speed;
    }

    public static float MoveSpeed {
        //return startMoveSpeed * gameSpeed to know how fast things are moving
        get { return speed * speedMultiplier; }
    }

    public static float SpeedMultiplier
    {
        //return the speed multiplier, which is incremented
        get { return speedMultiplier; }
    }
}
