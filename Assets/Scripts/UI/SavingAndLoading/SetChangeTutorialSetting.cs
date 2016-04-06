using UnityEngine;
using System.Collections;

public class SetChangeTutorialSetting : MonoBehaviour {

	public void ChangeTutorialSetting(bool _setting) 
	{
		if (GameObject.FindGameObjectWithTag ("Data"))
			GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ().PlayTutorial = _setting;
	}
}
