using UnityEngine;
using System.Collections;

public class TrailTriggerDetection : MonoBehaviour {

    [SerializeField]
    private string destroyTag = "Obstacle";

    private TrailMovementTest trailMovement;

    private int numberInList;

    void Start() {
        trailMovement = GetComponentInParent<TrailMovementTest>();
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
        trailMovement.DestroyTrailParts(numberInList, true);
    }

    public int NumberInList {
        set { numberInList = value; }
    }
}
