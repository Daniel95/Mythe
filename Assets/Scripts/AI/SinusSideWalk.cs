using UnityEngine;
using System.Collections;

public class SinusSideWalk : MonoBehaviour {
    [SerializeField]
    private float speed = 1;
    private float increment = 0.005f;
    private float maxSpeed = 8f;
    [SerializeField]
    private float maxRange;
    private float range =0;
    private float xMiddle = 0;
    private bool newDirection = true;

    void OnEnable()
    {
        speed = 0;
        maxRange = 0;
    }

    void FixedUpdate()
    {
        if(speed < maxSpeed)
        {
            speed += increment;
        }
        if(maxRange < maxSpeed/2f)
        {
            maxRange += increment;
        }
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
