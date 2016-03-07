using UnityEngine;
using System.Collections;

public class PlayerTrailRotation : MonoBehaviour {

	[SerializeField]
	private float maxSpeed	=	5;

	/** hoe zwaarder het object, hoe slechter hij kan bijsturen */
	[SerializeField]
	private float mass		=	20;

	/** boolean of het object de richting op kijkt waar we naar toe bewegen */
	[SerializeField]
	private bool followPath = false;

	[SerializeField]
	private float speed = 6.5f;

	//[SerializeField]
	private GameObject targetObject;

	[SerializeField]
	private string targetTag;

	/** Vector om onze huidige velocity bij te houden (x en y stap) */
	private Vector2 currentVelocity;
	/** Vector om onze huidige positie bij te houden (x en y positie) */
	private Vector2 currentPosition;
	/** Vector om de locatie bij te houden waar we heen willen */
	private Vector2 currentTarget;

	private Vector2 target;

	private Vector2 arriveTarget;

	void Start () {
		targetObject = GameObject.FindWithTag(targetTag);
		// we starten zonder beweging (geen velocity)
		currentVelocity = new Vector2(0, 0);
		// we nemen de huidige positie over in een eigen variabele
		currentPosition = transform.position;
		Seek ();
		setTarget ();
	}

	// Elke frametick kijken we hoe we moeten sturen
	void Update () {
		targetObject = GameObject.FindWithTag(targetTag);
		Seek();
		setTarget ();
	}

	private void setTarget() {
		//target = Camera.main.ScreenToWorldPoint(targetObject);
		target.x = targetObject.transform.position.x;
		target.y = targetObject.transform.position.y;
		//target.y = targetObject.transform.localPosition.y;

		currentTarget = target;

		arriveTarget.x = target.x;
		arriveTarget.y = target.y - 1f;
	}

	void Seek () {

		// we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld het mikpunt)		
		Vector2 desiredStep = currentTarget - currentPosition;

		if (desiredStep.magnitude < 0.7f) {
			transform.position = Vector3.MoveTowards(transform.position, arriveTarget, speed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else {
			//transform.LookAt (targetObject.transform);
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

			currentPosition += currentVelocity * Time.deltaTime;
			transform.position = currentPosition;


			// roteer het object in de goede richting
			if(followPath){
				float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		}
	}
}
