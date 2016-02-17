using UnityEngine;
using System.Collections;

// deze Class kan functies aanroepen in SteeringVehicle.cs
public class WaypointsFollower : MonoBehaviour {

	// todo: zorg ervoor dat dit component een lijst met waypoints/Vectors kan bevatten (instelbaar vanuit de editor)
	private int waypoint = 0;
	private int[] waypointsX = new int[5];
	private int[] waypointsY = new int[5];
	GameObject targetIcon;
	PlayerMovement playerMovement;

	void Start () {
		// todo: als er al waypoints beschikbaar zijn: ga richting de eerste waypoint

		playerMovement = GetComponent<PlayerMovement>();
		targetIcon = GameObject.FindWithTag("target");

		for (int i = 0; i < 5; i++) {

			waypointsX[i] = Random.Range(-5,5);
			waypointsY[i] = Random.Range(-4,4);

		}
	}

	void Update () {
		// todo: checken of we al in de buurt zijn van de eerstvolgende waypoint: zo ja -> ga door naar het volgende waypoint (setTarget() op SteeringVehicle.cs)
		if (true) {
			Vector2 targetPosition = new Vector2(waypointsX[waypoint], waypointsY[waypoint]);
			playerMovement.setTarget(targetPosition);
			targetIcon.transform.position = targetPosition;
			waypoint++;
		}
	}

	// zorg ervoor dat er een addWayPoint method is
	
}
