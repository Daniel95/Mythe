using UnityEngine;
using System.Collections;

public class GetAttractedByMagnet : MonoBehaviour {
	private GameObject playerObject; 
	private MoveDown moveDown;

	void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
		moveDown = GetComponent<MoveDown> ();
	}

	void OnTriggerStay2D(Collider2D _other)
	{
		if (_other.gameObject.tag == Tags.magnetEffect) 
		{
			moveDown.StopMoving ();
			this.transform.position = Vector2.MoveTowards (transform.position, playerObject.transform.position, 8*Time.deltaTime);
		}
	}
}
