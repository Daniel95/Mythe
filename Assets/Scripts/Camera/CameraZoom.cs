using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    private float normalSize = 5f;
    private float superSize = 8f;
    [SerializeField]
    private float zoomSpeed = 0.1f;
    private Camera userCamera;
    private bool superForm;

    void Start()
    {
        userCamera = GetComponent<Camera>();
    }

    public void ZoomCameraOut() {
        StartCoroutine(ZoomOutProcess());
    }

    public void ZoomCameraIn() {
        StartCoroutine(ZoomInProcess());
    }

    IEnumerator ZoomOutProcess()
    {
        while (userCamera.orthographicSize <= superSize)
        {
            userCamera.orthographicSize += zoomSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ZoomInProcess()
    {
        while (userCamera.orthographicSize >= normalSize)
        {
            userCamera.orthographicSize -= zoomSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
