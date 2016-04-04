using UnityEngine;
using System.Collections;

public class HaveSamePositionAsTarget : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool rotatedAsTarget = false;
	void FixedUpdate () {
        transform.position = target.position;
        if(rotatedAsTarget)
        {
            transform.rotation = target.rotation;
        }
	}

    public Transform Target
    {
        set { target = value; }
    }
}
