using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagnetAttractor : MonoBehaviour {

    [SerializeField]
	private Transform playerObject;

    [SerializeField]
    private int duration = 8;

	void OnEnable()
	{
		StartCoroutine (WaitAndDestroy (duration));

	}

	void Update () 
	{
		transform.position = playerObject.position;
	}

	IEnumerator WaitAndDestroy(float waitTime) {
		yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);
	}

}
