using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailMovement : MonoBehaviour {

    [SerializeField]
    private TrailLengthHandler trailLengthHandler;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform trailConnectPoint;

    private PlayerMovement playerMovement;

    [SerializeField]
    private float trailAutoSpeedMultiplier = 4;

    [SerializeField]
    private float superModeSpeedMultiplier = 20;

    [SerializeField]
    private float distanceBetweenTrails = 0.5f;

    [SerializeField]
    private float neckDistance = 0.2f;

    private List<Transform> trailParts = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        StartTrail();
    }

    public void StartTrail() {
        StartCoroutine(WaitForObjectPool());
    }

    private IEnumerator WaitForObjectPool()
    {
        //wait one frame, so the object pool is loaded
        yield return new WaitForFixedUpdate();

        trailLengthHandler.StartTrailLengthUpdater();
        //StartCoroutine(TrailLengthHandler());
    }

    
    void FixedUpdate () {
        Vector2 lastPosition = trailConnectPoint.position;

        // Update the movement of the Trails
        for (int i = 0; i < trailParts.Count; i++) {
            
            //so i dont have to wirte trailsParts[i] all the time
            Transform currentTrail = trailParts[i];

            //the difference in vector to the target
            Vector2 vectorToTarget = lastPosition - new Vector2(currentTrail.position.x, currentTrail.position.y);

            //calculate the angle to our target
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

            //use the angle to get the rotation to our target
            currentTrail.rotation = Quaternion.Euler(0, 0, angle);

            //give the trail gravity
            Vector3 velocity = new Vector3(0, -GameSpeed.MoveSpeed * 50, 0);

            float minDistance = distanceBetweenTrails;

            if (i == 0) minDistance = neckDistance;

            //float minDistance = distanceBetweenTrails;
            if (Vector2.Distance(currentTrail.position, lastPosition) > minDistance)
            {
                //move to the object, the further the object is, the faster we move. we use this to counter the gravity of the trail
                velocity += (new Vector3(vectorToTarget.x, vectorToTarget.y, 0) * trailAutoSpeedMultiplier) * (GameSpeed.SpeedMultiplier + GameSpeed.ExtraSpeed * superModeSpeedMultiplier);

                //move when the players moves
                velocity += currentTrail.transform.up * playerMovement.TotalSpeed;
            }

            //give the trailparts its velocity
            currentTrail.GetComponent<Rigidbody2D>().velocity = velocity;

            //set lastPosition on our new position. we use this so we know where the next trail parts needs to rotate to.
            lastPosition = currentTrail.transform.position;
        }
    }

    public List<Transform> TrailParts {
        get { return trailParts; }
    }

    public Transform TrailConnectPoint {
        get { return trailConnectPoint; }
    }

    public float DistanceBetweenTrails
    {
        get { return distanceBetweenTrails; }
    }

    public float NeckDistance {
        get { return neckDistance; }
    }
}
