using UnityEngine;
using System.Collections;

public class TrailTriggerDetection : MonoBehaviour {

    [SerializeField]
    private string destroyTag = "Obstacle";

    private TrailMovementTest trailMovement;

    private int numberInList;

    public bool removed;

    void Start() {
        trailMovement = GetComponentInParent<TrailMovementTest>();
    }

    public void Reset() {
        removed = false;
    }

    void OnTriggerEnter2D(Collider2D _other) {
        if (_other.CompareTag(destroyTag))
            Destroy();
    }
    
    void OnTriggerCollision2D(Collision2D _other)
    {
        if (_other.transform.CompareTag(destroyTag))
            Destroy();
    }

    public void Destroy() {
        if(!removed) trailMovement.RemoveTrailParts(numberInList, true);
    }

    public int NumberInList {
        set { numberInList = value; }
    }

    public bool Removed {
        set { removed = value; }
    }
}
