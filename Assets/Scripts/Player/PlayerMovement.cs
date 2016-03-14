using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float maxSpeed = 5;

	/** hoe zwaarder het object, hoe slechter hij kan bijsturen */
	[SerializeField]
	private float mass = 20;

	/** boolean of het object de richting op kijkt waar we naar toe bewegen */
	[SerializeField]
	private bool followPath = false;

	[SerializeField]
	private GameObject trail;

	/** Vector om onze huidige velocity bij te houden (x en y stap) */
	private Vector2 currentVelocity;
	/** Vector om onze huidige positie bij te houden (x en y positie) */
	private Vector2 currentPosition;
	/** Vector om de locatie bij te houden waar we heen willen */
	private Vector2 currentTarget;

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

    private Rigidbody2D rb;

	float getTrailSpeed=TrailMovement.trailDownForce;

	void Start () {
		// we starten zonder beweging (geen velocity)
		currentVelocity = new Vector2(0, 0);
		// we nemen de huidige positie over in een eigen variabele
		currentPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();
	}

	// Elke frametick kijken we hoe we moeten sturen
	void FixedUpdate () {
        // we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld het mikpunt)		
        Vector2 desiredStep = currentTarget - currentPosition;

        if (Vector3.Distance(transform.position, currentTarget) < minMoveDistance)
        {
            spawnSpeed = stillSpawnSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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

            rb.velocity = transform.up * maxSpeed;

            Vector3 dir = new Vector3(currentTarget.x, currentTarget.y, 0f) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

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

    /*
	private void getColor(){
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

	private IEnumerator spawnObject(){
		Instantiate(trail, transform.position+new Vector3(0,0,+1), transform.rotation);
		getColor ();
		trail.GetComponent<SpriteRenderer> ().color = new Color(red,green,blue);
		yield return new WaitForSeconds (spawnSpeed);
		StartCoroutine (spawnObject ());
	}
	*/
}
