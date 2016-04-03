using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RainbowEffect : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 1;

    private float fading = 0.01f;

    private float red = 1;
    private float green = 0;
    private float blue = 0;

    private List<Color> colors = new List<Color>() {
        Color.red,
        Color.yellow,
        Color.green,
        Color.blue,
        //new Color(255,0,0),
        //new Color(255,188,0),
        //new Color(255,255,0),
        //new Color(77,255,0),
        //new Color(0,73,255),
        //new Color(149,0,255),
        //new Color(255,0,255),
    };

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
    /*
    void Update () {
        
        if (!isUI)
            sprite.color = GetColor();
        else
            image.color = GetColor();
            
    }
*/
    void FixedUpdate() {
        GetColor();
        if (!isUI)
            sprite.color = new Color(red, green, blue);
        else
            image.color = new Color(red, green, blue);
    }

    public void StartColor(int _attachedTrailColorIndex) {
        colorIndex = _attachedTrailColorIndex - 1;
        if (colorIndex < 0)
            colorIndex = colors.Count - 1;
    }

    /*
    private Color GetColor() {

        int nextColorIndex = colorIndex + 1;
        if (nextColorIndex >= colors.Count)
            nextColorIndex = 0;

        Color newColor = Color.Lerp(colors[colorIndex], colors[nextColorIndex], Mathf.PingPong(Time.time, 1));

        if (newColor == colors[nextColorIndex]) {
            colorIndex = nextColorIndex;
        }

        return newColor;
    }*/

    private void GetColor()
    {
        if (red >= 1 && green < 1 && blue <= 0)
        {
            green += fading;
        }
        else if (red >= 0 && green >= 1 && blue <= 0)
        {
            red -= fading;
        }
        else if (red <= 0 && green >= 1 && blue < 1)
        {
            blue += fading;
        }
        else if (red <= 0 && green >= 0 && blue >= 1)
        {
            green -= fading;
        }
        else if (red < 1 && green <= 0 && blue >= 1)
        {
            red += fading;
        }
        else if (red >= 1 && green <= 0 && blue >= 0)
        {
            blue -= fading;
        }
    }

    public int ColorIndex {
        get { return colorIndex; }
    }
}
