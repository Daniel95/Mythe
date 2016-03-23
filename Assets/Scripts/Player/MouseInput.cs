using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	PlayerMovement playerMovement;
	GameObject targetIcon;
    [SerializeField]
    private float offset = 1f;
	// Use this for initialization
	void Start () {

		playerMovement = GetComponent<PlayerMovement>();
		targetIcon = GameObject.FindWithTag("target");
	}
	
	// Update is called once per frame
	void Update () {
		
			Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPosition.y += offset;
			playerMovement.setTarget(targetPosition);
			targetIcon.transform.position = targetPosition;

	}
}
