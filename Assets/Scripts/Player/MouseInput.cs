using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	PlayerMovement playerMovement;

    [SerializeField]
	Transform targetIcon;

    [SerializeField]
    private float offset = 1f;
	// Use this for initialization
	void Start () {

		playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
			Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPosition.y += offset;
			playerMovement.setTarget(targetPosition);
			targetIcon.position = targetPosition;

	}
}
