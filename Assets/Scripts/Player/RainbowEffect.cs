using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RainbowEffect : MonoBehaviour {

	private float red = 1;
	private float green = 0;
	private float blue = 0;

	[SerializeField]
	private float fading = 0.02f;

	void FixedUpdate () {
		getColor ();
        if(this.GetComponent<SpriteRenderer>() != null)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(red, green, blue);
        }
    }

	private void getColor () {
		if(red >= 1 && green < 1 && blue <= 0){
			green += fading;
		} else if(red >= 0 && green >= 1 && blue <= 0){
			red -= fading;
		} else if(red <= 0 && green >= 1 && blue < 1){
			blue += fading;
		} else if(red <= 0 && green >= 0 && blue >= 1){
			green -= fading;
		} else if(red < 1 && green <= 0 && blue >= 1){
			red += fading;
		} else if(red >= 1 && green <= 0 && blue >= 0){
			blue -= fading;
		}
	}
}
