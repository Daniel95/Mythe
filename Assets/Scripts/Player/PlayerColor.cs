using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

    private RainbowEffect firstTrailRainbowEffect;

    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (firstTrailRainbowEffect != null)
            spriteRenderer.color = firstTrailRainbowEffect.CurrentColor;
	}

    public RainbowEffect FirstTrailRainbowEffect {
        set { firstTrailRainbowEffect = value; }
    }
}
