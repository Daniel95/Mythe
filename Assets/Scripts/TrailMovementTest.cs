using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailMovementTest : MonoBehaviour {


    [SerializeField]
    private string trailPoolName = "TrailTest";

    [SerializeField]
    private int trailStartLength = 4;

    [SerializeField]
    private int trailMaxLength = 20;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform trailConnectPoint;

    private PlayerMovement playerMovement;

    [SerializeField]
    private float trailAutoSpeedMultiplier = 4;

    [SerializeField]
    private float superModeSpeedMultiplier;

    [SerializeField]
    private float distanceBetweenTrails = 0.5f;

    [SerializeField]
    private float neckDistance = 0.2f;

    [SerializeField]
    private HealthBar healthBar;

    private float healthPerTrail = 0;

    private int trailsAmount = 0;

    //[SerializeField]
    //private float trailScale = 0.5f;

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

        healthPerTrail = healthBar.MaxHealth / trailMaxLength;

        StartCoroutine(TrailLengthHandler());
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

    public void StartTrailLengthHandler() {
        StartCoroutine(TrailLengthHandler());
    }

    IEnumerator TrailLengthHandler()
    {
        while (healthBar.CurrentHealth != 0)
        {
            trailsAmount = Mathf.RoundToInt(healthBar.CurrentHealth / healthPerTrail);

            //spawn trails
            if (trailsAmount > trailParts.Count)
            {
                int difference = trailsAmount - trailParts.Count;
                for (int i = difference; i > 0; i--)
                {
                    SpawnTrail();
                }
                //remove trails
            }
            else if (trailsAmount < trailParts.Count)
            {
                DestroyTrailParts(trailsAmount, false);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SpawnTrail() {
        if (trailParts.Count < trailMaxLength)
        {
            //get the object out of the pool
            GameObject spawnedObject = ObjectPool.instance.GetObjectForType(trailPoolName, true);

            spawnedObject.transform.parent = transform;

            //add the object to the trail list
            trailParts.Add(spawnedObject.transform);

            //set the position of the trail
            if (trailParts.Count == 1) spawnedObject.transform.position = trailConnectPoint.position;
            else spawnedObject.transform.position = trailParts[trailParts.Count - 2].position;

            spawnedObject.GetComponent<MoveDown>().enabled = false;
			spawnedObject.GetComponent<InteractableObject> ().isEnabled = false;
			//spawnedObject.GetComponent<InteractableObject>().enabled = false;
            //give the trailpart its number in the list, we use this when we remove the trail part later.
            spawnedObject.GetComponent<TrailTriggerDetection>().NumberInList = trailParts.Count;

            DistanceJoint2D distanceJoint2D = spawnedObject.GetComponent<DistanceJoint2D>();

            
            if (trailParts.Count == 1)
            {
                distanceJoint2D.connectedBody = trailConnectPoint.GetComponent<Rigidbody2D>();
                distanceJoint2D.distance = neckDistance;
            }
            else {
                distanceJoint2D.connectedBody = trailParts[trailParts.Count - 2].GetComponent<Rigidbody2D>();
                distanceJoint2D.distance = distanceBetweenTrails;
            }
            distanceJoint2D.enabled = true;
        }
    }

    public void DestroyTrailParts(int _numberInList, bool _doDamage) {

        //do damage to the players healthbar when the trail is being cut off
        if(_doDamage)
            healthBar.addValue((_numberInList - trailParts.Count) * healthPerTrail);

        //save the list length, because we dont want it to change while we are looping the for loop
        int listLenght = trailParts.Count;

        //look at the numberInList of the trail part, destroy this trail and every trail that is higher in the list than us.
        for (int i = _numberInList; i < listLenght; i++) {

            trailParts[_numberInList].GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            trailParts[_numberInList].GetComponent<DistanceJoint2D>().enabled = false;

            trailParts[_numberInList].GetComponent<MoveDown>().enabled = true;
			trailParts [_numberInList].GetComponent<InteractableObject> ().isEnabled = true;
            trailParts.Remove(trailParts[_numberInList]);
        }
    }
}
