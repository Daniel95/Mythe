using UnityEngine;
using System.Collections;

public class PlayerTrailRotation : MonoBehaviour {

	private Vector3 fwdSpeed;
	private Vector3 scale;

	private float scaling = 0.01f;
	private float speed = -0.025f;

	// Use this for initialization
	void Start () {
		fwdSpeed = new Vector3 (0, speed, +0.1f);
		scale = new Vector3 (scaling, scaling, scaling);
	}

	// Update is called once per frame
	void Update () {
		transform.position += fwdSpeed;
		transform.localScale -= scale;
		if (transform.localScale.x <= 0) {
			Destroy (gameObject);
		}
	}
}
