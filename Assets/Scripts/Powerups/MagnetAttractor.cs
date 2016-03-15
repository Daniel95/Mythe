using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagnetAttractor : MonoBehaviour {
	private GameObject playerObject; 

	void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
		StartCoroutine (WaitAndDestroy (10));
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
