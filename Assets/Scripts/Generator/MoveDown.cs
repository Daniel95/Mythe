using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour {

	//Test script please ignore.

	[SerializeField]
	private float moveSpeed;

	void FixedUpdate () {
		transform.Translate (new Vector3 (0, moveSpeed, 0), Space.World);
	}
}
