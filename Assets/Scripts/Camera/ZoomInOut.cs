using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {

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
    void Update()
    {
        superForm = GameObject.Find("Canvas/Healthbar/Bar").GetComponent<HealthBar>().SuperForm;
        if (superForm)
        {
            
            if (camera.orthographicSize <= superSize)
            {
                camera.orthographicSize += zoomSpeed;
            }
        }
        else
        {
            if (camera.orthographicSize >= normalSize)
            {
                camera.orthographicSize -= zoomSpeed;
            }
        }
    }

}
