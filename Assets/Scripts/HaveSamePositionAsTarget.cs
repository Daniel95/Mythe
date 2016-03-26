using UnityEngine;
using System.Collections;

public class HaveSamePositionAsTarget : MonoBehaviour {
    [SerializeField]
    private Transform target;
	void FixedUpdate () {
        transform.position = target.position;
	}
}
