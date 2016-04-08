using UnityEngine;
using System.Collections;

public class SetStateOnStart : MonoBehaviour {

    [SerializeField]
    private bool state;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(state);
	}
}
