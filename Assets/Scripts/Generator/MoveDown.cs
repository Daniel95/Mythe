using UnityEngine;

public class MoveDown : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -GameSpeed.MoveSpeed, 0));
    }
}

