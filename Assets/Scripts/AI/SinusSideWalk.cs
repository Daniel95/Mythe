using UnityEngine;
using System.Collections;

public class SinusSideWalk : MonoBehaviour {
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float maxRange;
    private float range =0;
    private float xMiddle = 0;
    private bool newDirection = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var basetime = Time.time * speed;

        //reken uit hoever de sine curve is
        var sinPos = Mathf.Sin(basetime += Time.fixedDeltaTime);

        if (sinPos >= 0.99f || sinPos <= -0.99f)
        {
            if (newDirection)
            {
                range = Random.Range(0, maxRange);
                if (transform.position.x + range * 2 > maxRange && sinPos < 0)
                {
                    range = (maxRange - transform.position.x) / 2;
                }
                else if (transform.position.x + -range * 2 < -maxRange)
                {
                    range = (-maxRange + transform.position.x) / -2;
                }
                xMiddle = transform.position.x - range * sinPos;
                newDirection = false;
            }
        }
        else
        {
            newDirection = true;
        }


        this.transform.position =
            new Vector3(xMiddle + sinPos * range,
                this.transform.position.y,
                this.transform.position.z);
    }

}
