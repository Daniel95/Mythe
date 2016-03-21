using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    private float normalSize = 5f;
    private float superSize = 8f;
    [SerializeField]
    private float zoomSpeed = 0.1f;
    private Camera camera;
    private bool superForm;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void ZoomCameraOut() {
        StartCoroutine(ZoomOutProcess());
    }

    public void ZoomCameraIn() {
        StartCoroutine(ZoomInProcess());
    }

    IEnumerator ZoomOutProcess()
    {
        while (camera.orthographicSize <= superSize)
        {
            camera.orthographicSize += zoomSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ZoomInProcess()
    {
        while (camera.orthographicSize >= normalSize)
        {
            camera.orthographicSize -= zoomSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
