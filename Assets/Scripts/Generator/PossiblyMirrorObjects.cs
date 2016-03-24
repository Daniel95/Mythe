using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PossiblyMirrorObjects : MonoBehaviour {

	void OnEnable()
	{
		if (Random.value < 0.5)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
