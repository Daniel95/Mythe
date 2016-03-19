using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 5;

    [SerializeField]
    private float rotateSpeed = 1;

	[SerializeField]
	private string trailName;

    [SerializeField]
    private Transform spawnPoint;

	//the current target we are moving towards
	private Vector2 currentTarget;

    private Quaternion targetRotation;

	private float red = 1f;
	private float green = 0f;
	private float blue = 0f;

	private float fading = 0.2f;
	private float spawnSpeed = 0.1f;

	[SerializeField]
	private float movingSpawnSpeed = 0.1f;

	[SerializeField]
	private float stillSpawnSpeed = 0.2f;

    private Rigidbody2D rb;

	float getTrailSpeed=TrailMovement.trailDownForce;

	void Start () {
        StartCoroutine(SpawnObject());

        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
        //the difference in vector to the target
        Vector2 vectorToTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);

        //the players movespeed it the vector to target multiplied by movespeed
        //so the farther away the target is, the faster the players speed
        rb.velocity = vectorToTarget * moveSpeed;

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

        //use the angle to get the rotation to our target
        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //move to the targetrotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);

        //the speed of the player, the x speed + y speed (made absulute) = total speed.
        float speed = Mathf.Abs(vectorToTarget.x + vectorToTarget.y);

        TrailMovement.trailDownForce = -0.01f;

        spawnSpeed = movingSpawnSpeed - (speed / 30) * GameSpeed.SpeedMultiplier;
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

    
	private void GetColor(){
		if(red >= 1 && green < 1 && blue <= 0){
			green += fading;
		} else if(red >= 0 && green >= 1 && blue <= 0){
			red -= fading;
		} else if(red <= 0 && green >= 1 && blue < 1){
			blue += fading;
		} else if(red <= 0 && green >= 0 && blue >= 1){
			green -= fading;
		} else if(red < 1 && green <= 0 && blue >= 1){
			red += fading;
		} else if(red >= 1 && green <= 0 && blue >= 0){
			blue -= fading;
		}
	}

	private IEnumerator SpawnObject(){
		//Instantiate(trail, transform.position+new Vector3(0,0,+1), transform.rotation);

        GameObject trail = ObjectPool.instance.GetObjectForType("Trail", false);
        trail.transform.position = spawnPoint.position + new Vector3(0, 0, +1);
        trail.transform.rotation = transform.rotation;


        GetColor ();
		trail.GetComponent<SpriteRenderer> ().color = new Color(red,green,blue);
		yield return new WaitForSeconds (spawnSpeed);
		StartCoroutine (SpawnObject ());
	}
	
}
