using UnityEngine;
using System.Collections;

public class KillGameOnExit : MonoBehaviour {

	void Update ()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

	}
}
