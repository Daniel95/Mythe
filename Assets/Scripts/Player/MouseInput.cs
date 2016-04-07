using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	PlayerMovement playerMovement;

    [SerializeField]
	Transform targetIcon;

    private Vector2 targetStartPos;

    private bool updating;

	// Use this for initialization
	void Awake () {
		playerMovement = GetComponent<PlayerMovement>();
        targetStartPos = targetIcon.position;
    }

    void OnEnable() {
        StartUpdatingInput();
    }

    void OnDisable()
    {
        StopUpdatingInput();
        targetIcon.position = targetStartPos;
    }

    private IEnumerator UpdateInput()
    {
        while (updating)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerMovement.setTarget(targetPosition);
            targetIcon.position = targetPosition;
            yield return null;
        }
    }

    public void StopUpdatingInput() {
        targetIcon.position = targetStartPos;
        updating = false;
    }

    public void StartUpdatingInput()
    {
        if (!updating)
        {
            updating = true;
            StartCoroutine(UpdateInput());
        }
    }
}
