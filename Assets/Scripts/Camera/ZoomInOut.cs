using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {

    private float normalSize = 5f;
    private float superSize = 8f;
    [SerializeField]
    private float zoomSpeed = 0.1f;
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void ZoomOut()
    {
        StartCoroutine(ZoomOutProcess());
    }
    public void ZoomIn()
    {
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
