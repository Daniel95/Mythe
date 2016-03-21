using UnityEngine;
using System.Collections;

public class TrailMovement : MonoBehaviour {

	[SerializeField]
	public static float trailDownForce;

	void FixedUpdate () {
		transform.Translate (new Vector3 (0, trailDownForce, 0));
	}
}
