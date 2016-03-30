using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrailRainbowSlave : MonoBehaviour {

	private float red;
	private float green;
	private float blue;
	
	// Update is called once per frame
	void Update () {
		TrailRainbowMaster.getColor ();

		red = TrailRainbowMaster.trail_red;
		green = TrailRainbowMaster.trail_green;
		blue = TrailRainbowMaster.trail_blue;

		if(this.GetComponent<SpriteRenderer>() != null)
		{
			this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
		}
		else
		{
			this.GetComponent<Image>().color = new Color(red, green, blue);
		}
	}
}
