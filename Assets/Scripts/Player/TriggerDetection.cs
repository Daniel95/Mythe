using UnityEngine;
using System.Collections;

public class TriggerDetection : MonoBehaviour {
    
   
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private GameObject WaterBar;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
	
    //this triggerenter is for the player so it can interact with other objects.
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<InteractableObject>().DestroyOnTouch)
        {
            ObjectPool.instance.PoolObject(other.gameObject);
        }
        float _value = other.gameObject.GetComponent<InteractableObject>().Value;
        if(WaterBar != null)
        {
            WaterBar.GetComponent<WaterBar>().addValue(_value);
        }
        
    }
}
