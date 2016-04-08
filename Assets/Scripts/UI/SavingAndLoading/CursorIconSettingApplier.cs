using UnityEngine;
using System.Collections;

public class CursorIconSettingApplier : MonoBehaviour {
	private OptionsData optionsData;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (GameObject.FindGameObjectWithTag ("Data")) {
			optionsData = GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ();
		}
		if (optionsData.GetCursor == false) 
		{
			spriteRenderer.sprite = null;
		}


	}
}
