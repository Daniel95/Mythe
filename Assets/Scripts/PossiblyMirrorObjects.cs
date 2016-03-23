using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PossiblyMirrorObjects : MonoBehaviour {

	void OnEnable()
	{
        GetComponent<BoxCollider2D>().enabled = true;
		if (Random.value < 0.5)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
