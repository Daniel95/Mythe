using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField]
    private float moveDownSpeed = 0.11f;

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -moveDownSpeed * GameSpeed.Speed, 0));
    }
}

