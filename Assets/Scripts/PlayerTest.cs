using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {
    
    private float speedx;
    private float speedy;
    private float speed = 4;
    private Rigidbody2D rigidbody2D;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        speedx = Input.GetAxis("Horizontal");
        speedy = Input.GetAxis("Vertical");
        
        rigidbody2D.velocity = new Vector2(speedx *speed,speedy *speed);
	}
}
