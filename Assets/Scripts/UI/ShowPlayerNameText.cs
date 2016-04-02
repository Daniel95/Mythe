using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowPlayerNameText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("Data"))
            GetComponent<DynamicText>().AddString(GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>().Name);
	}
}
