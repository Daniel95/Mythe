using UnityEngine;
using System.Collections;

public class GetAttractedByMagnet : MonoBehaviour {
	private GameObject playerObject; 
	private MoveDown moveDown;

	private bool haveIBeenAttracted;

	void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
		moveDown = GetComponent<MoveDown> ();
	}

	void OnEnable()
	{
		haveIBeenAttracted = false;
	}

	void OnTriggerEnter2D(Collider2D _other)
	{
		if (_other.gameObject.tag == Tags.magnetEffect) 
		{
            moveDown.Move = false;
			haveIBeenAttracted = true;
		}
	}

	void Update()
	{
		if (haveIBeenAttracted && playerObject != null) 
		{
			if (playerObject != null)
				this.transform.position = Vector2.MoveTowards (transform.position, playerObject.transform.position, 8 * Time.deltaTime);
			else {
				moveDown.Move = true;
			}

		}
	}
}
