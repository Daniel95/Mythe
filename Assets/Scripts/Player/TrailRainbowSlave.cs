using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrailRainbowSlave : MonoBehaviour {

	[SerializeField]
	private  GameObject Player = GameObject.Find("Player");

	private float red;
	private float green;
	private float blue;
	
	// Update is called once per frame
	void Update () {
		Player.GetComponent<TrailRainbowMaster>().getColor();

		red = Player.GetComponent<TrailRainbowMaster>().trail_red;
		green = Player.GetComponent<TrailRainbowMaster>().trail_green;
		blue = Player.GetComponent<TrailRainbowMaster>().trail_blue;

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
