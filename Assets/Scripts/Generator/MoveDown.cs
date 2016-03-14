using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private bool move = true;

    void FixedUpdate()
    {
        if(move) transform.Translate(new Vector3(0, -GameSpeed.MoveSpeed, 0),Space.World);
    }

    public bool Move {
        set { move = value; }
    }
}
