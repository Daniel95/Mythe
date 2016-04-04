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
    [SerializeField]
    private bool randomPositions = false;
    void Start () {
        //sets up the position and direction the object should go.
        direction = new Vector2(speed, 0f);

        Vector2 temp = transform.position;
        temp.x = Xmin;
        transform.position = temp;
	}
	
	void FixedUpdate () {

        //change direction when it reaches its Xmin or Xmax.
        if(transform.position.x > Xmax)
        {
            direction = new Vector2(-speed, 0f);
            gameObject.transform.localScale *= -1;
            if(randomPositions)
            {
                Xmin = Random.Range(-2.8f, Xmax);
            }
        }
        else if (transform.position.x < Xmin)
        {
            direction = new Vector2(speed, 0f);
            gameObject.transform.localScale *= -1;
            if (randomPositions)
            {
                Xmax = Random.Range(Xmin,2.8f);
            }
        }

        //moves the object with the assigned direction.
        transform.Translate(direction);
    }
}
