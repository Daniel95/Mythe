using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	PlayerMovement playerMovement;

    [SerializeField]
	Transform targetIcon;

    private Vector2 targetStartPos;

    private bool updating;

    private bool targetEnabled = true;

	// Use this for initialization
	void Awake () {
		playerMovement = GetComponent<PlayerMovement>();
        targetStartPos = targetIcon.position;

        if(GameObject.FindGameObjectWithTag("Data"))
            targetEnabled = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>().GetCursor;
    }

    void OnEnable() {
        StartUpdatingInput();
    }

    void OnDisable()
    {
        StopUpdatingInput();
    }

    private IEnumerator UpdateInput()
    {
        while (updating)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerMovement.setTarget(targetPosition);
            if(targetEnabled)
                targetIcon.position = targetPosition;
            yield return null;
        }
    }

    public void StopUpdatingInput() {
        if (targetIcon != null)
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
