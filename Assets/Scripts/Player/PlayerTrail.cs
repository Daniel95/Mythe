using UnityEngine;
using System.Collections;

public class PlayerTrail : MonoBehaviour {

	private Vector3 fwdSpeed;
	private Vector3 scale;

	private float scaling = 0.05f;
	private float speed = -0.025f;

	// Use this for initialization
	void Start () {
		fwdSpeed = new Vector3 (0, speed, +0.0001f);
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
