using UnityEngine;
using System.Collections;

public class RainbowEffect : MonoBehaviour {

	private float red = 1;
	private float green = 0;
	private float blue = 0;

	[SerializeField]
	private float fading = 0.02f;
	
	// Update is called once per frame
	void Update () {
		getColor ();
		this.GetComponent<SpriteRenderer> ().color = new Color(red,green,blue);
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
