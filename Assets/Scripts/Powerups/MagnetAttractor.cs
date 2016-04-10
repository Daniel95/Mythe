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
		StartCoroutine ("WaitAndDestroy", duration / GameSpeed.SpeedMultiplier);
	}

	void Update () 
	{
		transform.position = playerObject.position;
	}

    public void ResetPowerup()
    {
		StopCoroutine("WaitAndDestroy");
        StartCoroutine("WaitAndDestroy",duration / GameSpeed.SpeedMultiplier);
    }

    IEnumerator WaitAndDestroy(float waitTime) {
		yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);
	}

}
