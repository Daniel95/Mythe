using UnityEngine;
using System.Collections;

public class SideWalk : MonoBehaviour {

    //this will make an object move side ways on the x max.

    [SerializeField]
    private float Xmin;
    [SerializeField]
    private float Xmax;
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private bool left = false;
    private Vector3 scale;
    void Start()
    {
        
    }
    void OnEnable () {
        scale = new Vector3(0.6f, 0.6f, 0.6f);
        StartCoroutine(MoveRight());
    }
    IEnumerator MoveLeft()
    {
        transform.localScale = -scale;
        direction = new Vector3(-speed, 0f, 0f);
        while (transform.position.x > Xmin)
        {
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(MoveRight());
    }
    IEnumerator MoveRight()
    {
        transform.localScale = scale;
        direction = new Vector3(speed, 0f, 0f);
        while (transform.position.x < Xmax)
        {
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(MoveLeft());
    }

    void FixedUpdate () {
        //moves the object with the assigned direction.
        transform.Translate(direction);
    }
}
