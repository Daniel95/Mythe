using UnityEngine;
using System.Collections;

public class SetChangeVibration : MonoBehaviour {

	public void ChangeVibrationSetting(bool _setting) 
	{
		if (GameObject.FindGameObjectWithTag ("Data"))
			GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ().EnableVibration = _setting;
	}
}
