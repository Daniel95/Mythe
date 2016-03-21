using UnityEngine;
using System.Collections;

public class PlayerTrail : MonoBehaviour
{
	/*
	private Vector3 scale;

	private float scaling = 0.05f;
	//private float speed = -GameSpeed.MoveSpeed * GameSpeed.SpeedMultiplier;

	void Start () {
		//fwdSpeed = new Vector3 (0, speed, +0.0001f);
		scale = new Vector3 (scaling, scaling, scaling);
	}
*/
	[SerializeField]
	private float scaling;

	void FixedUpdate()
	{
		transform.position += new Vector3(0, -GameSpeed.MoveSpeed, +0.0001f);
		transform.localScale -= new Vector3 (scaling, scaling, scaling);

		if (transform.localScale.x <= 0) {
			Destroy (gameObject);
		}

	}
}
/*
{

	private Vector3 fwdSpeed;
	private Vector3 scale;

	private float scaling = 0.05f;
	private float speed = -GameSpeed.MoveSpeed * GameSpeed.SpeedMultiplier;

	// Use this for initialization
	void Start () {
		fwdSpeed = new Vector3 (0, speed, +0.0001f);
		scale = new Vector3 (scaling, scaling, scaling);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		speed = -GameSpeed.MoveSpeed * GameSpeed.SpeedMultiplier;
		//fwdSpeed = new Vector3 (0, speed, +0.0001f);
		transform.position += fwdSpeed;
		transform.localScale -= scale;
		if (transform.localScale.x <= 0) {
			Destroy (gameObject);
		}
	}
}
*/