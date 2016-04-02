using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speedMultiplier = 5;

    private float totalSpeed;

    [SerializeField]
    private float rotateSpeed = 1;

	[SerializeField]
	private string trailName;

    [SerializeField]
    private Transform spawnPoint;

	//the current target we are moving towards
	private Vector2 currentTarget;

    private Quaternion targetRotation;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        //the difference in vector to the target
        Vector2 vectorToTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);

        //the players speed it the vector to target multiplied by speedMultiplier
        //so the farther away the target is, the faster the players speed
        rb.velocity = vectorToTarget * speedMultiplier;

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

        //use the angle to get the rotation to our target
        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //move to the targetrotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);

        //the speed of the player, the x speed + y speed (made absulute) = total speed.
        totalSpeed = Mathf.Abs(vectorToTarget.x + vectorToTarget.y) * speedMultiplier;
    }

    
    public void setTarget(Vector2 target)
    {
        currentTarget = target;
    }

    // van buitenaf kun je de huidige target uitlezen
    public Vector2 Target
    {
        get
        {
            return currentTarget;
        }
    }

    public float TotalSpeed
    {
        get { return totalSpeed; }
    }
}
