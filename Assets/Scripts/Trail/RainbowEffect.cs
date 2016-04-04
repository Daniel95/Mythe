using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RainbowEffect : MonoBehaviour {

    private float fadeTime = 0.55f;

    private List<Vector3> colors = new List<Vector3>() {
        new Vector3(1,0,0),
        new Vector3(0,1,0),
        new Vector3(0,1,1),
        new Vector3(0,0,1),
        new Vector3(1,0,1),
        new Vector3(1,0,0),
    };

    private Vector3 colorCodes;

    private Vector3 velocity;

    [SerializeField]
    private int colorIndex = 1;

    private bool isUI;

    private SpriteRenderer sprite;

    private Image image;

    void Awake()
    {
        if (GetComponent<SpriteRenderer>() != null)
            sprite = GetComponent<SpriteRenderer>();
        else
        {
            isUI = true;
            image = GetComponent<Image>();
        }
    }
    
    void Update () {
        
        if (!isUI)
            sprite.color = GetColor();
        else
            image.color = GetColor();
            
    }

    public void StartColor(int _attachedTrailColorIndex) {
        colorIndex = _attachedTrailColorIndex - 1;
        if (colorIndex < 0)
            colorIndex = colors.Count - 1;
    }

    private Color GetColor() {

        int nextColorIndex = colorIndex + 1;
        if (nextColorIndex >= colors.Count)
            nextColorIndex = 0;

        colorCodes = Vector3.SmoothDamp(colorCodes, colors[nextColorIndex], ref velocity, fadeTime / GameSpeed.SpeedMultiplier - GameSpeed.ExtraSpeed);
        /*
        Vector3 distanceV3 = colorCodes - colors[nextColorIndex];
        float distanceF = Mathf.Abs(distanceV3.x) + Mathf.Abs(distanceV3.y) + Mathf.Abs(distanceV3.z);
        if (distanceF < 100) {
            colorIndex = nextColorIndex;
        }*/

        if (Vector3.Distance(colorCodes, colors[nextColorIndex]) < 0.1f) {
            colorIndex = nextColorIndex;
        }

        return new Color(colorCodes.x,colorCodes.y,colorCodes.z, 1);
    }

    public int ColorIndex {
        get { return colorIndex; }
    }
}
