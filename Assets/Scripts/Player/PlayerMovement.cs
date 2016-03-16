using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 5;

    [SerializeField]
    private float rotateSpeed = 1;

	[SerializeField]
	private GameObject trail;

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

    [SerializeField]
    private float minMoveDistance = 1.5f;

    [SerializeField]
    private float minRotateDistance = 0.1f;

    private Rigidbody2D rb;

	float getTrailSpeed=TrailMovement.trailDownForce;

	void Start () {
        StartCoroutine(SpawnObject());

        rb = GetComponent<Rigidbody2D>();
	}

	// Elke frametick kijken we hoe we moeten sturen
	void FixedUpdate () {



        if (Vector3.Distance(transform.position, currentTarget) < minMoveDistance)
        {
            spawnSpeed = stillSpawnSpeed;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            targetRotation = Quaternion.Euler(0, 0, 0);
            TrailMovement.trailDownForce = -0.1f;

            rb.velocity = Vector2.zero;
            rb.MovePosition(currentTarget);

            if (transform.rotation.eulerAngles.z <= -5f || transform.rotation.eulerAngles.z >= 5f)
            {
                //transform.rotation.eulerAngles.z = transform.rotation.eulerAngles.z / 2f;
            }
            else
            {
                //transform.rotation.eulerAngles.z = 0f;
            }
        }
        else
        {
            TrailMovement.trailDownForce = -0.01f;

            spawnSpeed = movingSpawnSpeed;

            rb.velocity = transform.up * moveSpeed;

            
            Vector2 vectorToTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            /*
            Vector3 dir = new Vector3(currentTarget.x, currentTarget.y, 0f) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            */
        }

        if (Mathf.Abs(transform.rotation.z - targetRotation.z) > minRotateDistance)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
        else transform.rotation = targetRotation;
    }

    void spawnTrail()
    {
        Instantiate(trail, transform.position, Quaternion.identity);
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
		Instantiate(trail, transform.position+new Vector3(0,0,+1), transform.rotation);
		GetColor ();
		trail.GetComponent<SpriteRenderer> ().color = new Color(red,green,blue);
		yield return new WaitForSeconds (spawnSpeed);
		StartCoroutine (SpawnObject ());
	}
	
}
