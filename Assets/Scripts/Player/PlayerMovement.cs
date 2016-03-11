using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private bool collided = false;
    private GameObject collidingObject;
    private float collidingObjectXsize;
    private float playerXsize;

    [SerializeField]
	private float maxSpeed	=	5;

	/** hoe zwaarder het object, hoe slechter hij kan bijsturen */
	[SerializeField]
	private float mass		=	20;

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

	float getTrailSpeed=TrailMovement.trailDownForce;

	void Start () {
        playerXsize = GetComponent<SpriteRenderer>().bounds.extents.x;

        // we starten zonder beweging (geen velocity)
        currentVelocity = new Vector2(0, 0);
		// we nemen de huidige positie over in een eigen variabele
		currentPosition = transform.position;
		//StartCoroutine (spawnObject());
		Seek ();
	}

	// Elke frametick kijken we hoe we moeten sturen
	void Update () {
		Seek();

	}

	void spawnTrail () {
		Instantiate(trail, transform.position, Quaternion.identity);
	}

	public void setTarget(Vector2 target) {
		currentTarget = target;
	}

	// van buitenaf kun je de huidige target uitlezen
	public Vector2 Target {
		get {
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
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("coll");
        if (coll.gameObject.tag == Tags.collider)
        {

            collided = true;
            collidingObject = coll.gameObject;
            collidingObjectXsize = collidingObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.collider)
        {
            collided = false;
        }

    }

    void Seek() {
        /*Vector3 dir = new Vector3(currentTarget.x,currentTarget.y,0f) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90 ;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * maxSpeed, ForceMode2D.Force);
        */
        
		// we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld het mikpunt)		
		Vector2 desiredStep = currentTarget - currentPosition;

        if (desiredStep.magnitude < 0.07f)
        {
            spawnSpeed = stillSpawnSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            TrailMovement.trailDownForce = -0.1f;

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
            // deze desiredStep mag niet groter zijn dan de maximale Speed
            //
            // als een vector ge'normalized' is .. dan houdt hij dezelfde richting
            // maar zijn lengte/magnitude is 1
            desiredStep.Normalize();

            // als je deze genormaliseerde vector weer vermenigvuldigt met de maximale snelheid dan
            // wordt de lengte van deze Vector maxSpeed (aangezien 1 x maxSpeed = maxSpeed)
            // de x en y van deze Vector wordt zo vanzelf omgerekend
            Vector2 desiredVelocity = desiredStep * maxSpeed;

            // bereken wat de Vector moet zijn om bij te sturen om bij de desiredVelocity te komen
            Vector2 steeringForce = desiredVelocity - currentVelocity;

            // uiteindelijk voegen we de steering force toe maar wel gedeeld door de 'mass'
            // hierdoor gaat hij niet in een rechte lijn naar de target
            // hoe zwaarder het object des te groter de bocht
            currentVelocity += steeringForce / mass;

            // Als laatste updaten we de positie door daar onze beweging (velocity) bij op te tellen
            if (!collided)
            {
                currentPosition += currentVelocity * Time.deltaTime;
            }
            else
            {

                if (transform.position.x + playerXsize < collidingObject.transform.position.x - collidingObjectXsize || transform.position.x - playerXsize > collidingObject.transform.position.x + collidingObjectXsize)
                {
                    currentPosition.y += currentVelocity.y * Time.deltaTime;
                }
                else
                {
                    if (transform.position.y > collidingObject.transform.position.y)
                    {
                        currentPosition -= new Vector2(0, -GameSpeed.MoveSpeed);
                    }
                    else
                    {
                        currentPosition += new Vector2(0, -GameSpeed.MoveSpeed);
                    }
                    currentPosition.x += currentVelocity.x * Time.deltaTime;
                }
            }
            transform.position = currentPosition;


            // roteer het object in de goede richting
            if (followPath)
            {
                float angle = (Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg) + 270f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    
		
	}
}
