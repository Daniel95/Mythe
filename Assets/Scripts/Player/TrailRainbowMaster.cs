using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrailRainbowMaster : MonoBehaviour {

	public float trail_red = 1;
	public float trail_green = 0;
	public float trail_blue = 0;

	[SerializeField]
	private float fading = 0.02f;

	public void getColor () {
		if(trail_red >= 1 && trail_green < 1 && trail_blue <= 0){
			trail_green += fading;
		} else if(trail_red >= 0 && trail_green >= 1 && trail_blue <= 0){
			trail_red -= fading;
		} else if(trail_red <= 0 && trail_green >= 1 && trail_blue < 1){
			trail_blue += fading;
		} else if(trail_red <= 0 && trail_green >= 0 && trail_blue >= 1){
			trail_green -= fading;
		} else if(trail_red < 1 && trail_green <= 0 && trail_blue >= 1){
			trail_red += fading;
		} else if(trail_red >= 1 && trail_green <= 0 && trail_blue >= 0){
			trail_blue -= fading;
		}
	}
}
