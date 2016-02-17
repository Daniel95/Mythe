using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {
    
    private float speedx;
    private float speedy;
    private float speed = 4;
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private GameObject WaterBar;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
	
	void Update () {
        speedx = Input.GetAxis("Horizontal");
        speedy = Input.GetAxis("Vertical");
        
        rigidbody2D.velocity = new Vector2(speedx *speed,speedy *speed);
	}


    //this triggerenter needs to be added for the player so it can interact with other objects.
    void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.GetComponent<InteractableObject>().DestroyOnTouch)
        {
            Destroy(other.gameObject);
        }
        float _value = other.gameObject.GetComponent<InteractableObject>().Value;
        if(WaterBar != null)
        {
            WaterBar.GetComponent<WaterBar>().addValue(_value);
        }
        
    }
}
