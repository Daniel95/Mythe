using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagnetAttractor : MonoBehaviour {
	private GameObject playerObject; 

	void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
	}

	void OnEnable()
	{
		StartCoroutine (WaitAndDestroy (8));

	}

	void Update () 
	{
		this.transform.position = playerObject.transform.position;
	}

	IEnumerator WaitAndDestroy(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		ObjectPool.instance.PoolObject (gameObject);
	}

}
