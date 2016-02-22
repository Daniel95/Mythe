using UnityEngine;
using System.Collections;

public class GameSpeed : MonoBehaviour {

    [SerializeField]
    private float gameSpeedIncrement = 0.001f;

    [SerializeField]
    private static float speed = 1;

    void FixedUpdate() {
        speed += gameSpeedIncrement;
    }

    public void SuperMode()
    {    

    }

    public static float Speed {
        get { return speed; }
    }
}
