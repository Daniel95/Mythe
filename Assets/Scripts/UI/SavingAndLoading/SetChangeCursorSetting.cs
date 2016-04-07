using UnityEngine;
using System.Collections;

public class SetChangeCursorSetting : MonoBehaviour {

	public void SetChangeCursor(bool _setting) 
	{
		if (GameObject.FindGameObjectWithTag ("Data"))
			GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ().EnableCursor = _setting;
	}
}
