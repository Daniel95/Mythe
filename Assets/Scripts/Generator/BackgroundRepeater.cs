using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {

    private float heigth;
    
    // Use this for initialization
    void Start () {
        
        heigth = (transform.FindChild("up").transform.position.y - transform.position.y) * 2f;

    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y < -heigth)
        {
            transform.Translate(new Vector2(0f, heigth));
        }
    }
}
