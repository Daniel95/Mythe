using UnityEngine;
using System.Collections;

public class TrailTriggerDetection : MonoBehaviour {

    private TrailLengthHandler trailLengthHandler;

    private int numberInList;

    private bool removed;

    private bool shielded;

	private TriggerDetection triggerDetection; 

    void Start() {
        trailLengthHandler = GetComponentInParent<TrailLengthHandler>();
		triggerDetection = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<TriggerDetection> ();
    }

    public void Reset() {
        removed = false;
    }

    void OnTriggerEnter2D(Collider2D _other) {
        if (_other.CompareTag(Tags.obstacle))
            Destroy();
    }
    
    void OnTriggerCollision2D(Collision2D _other)
    {
		if (_other.transform.CompareTag (Tags.obstacle)) 
		{
			if (triggerDetection.Hurtable) 
			{
				Destroy ();
				triggerDetection.makeUnHurtable ();
			}
		}
    }

    public void Destroy() {
        if(!removed && !shielded) trailLengthHandler.RemoveTrailParts(numberInList, true);
    }

    public int NumberInList {
        set { numberInList = value; }
    }

    public bool Removed {
        set { removed = value; }
    }

    public bool Shielded
    {
        set { shielded = value; }
    }
}
