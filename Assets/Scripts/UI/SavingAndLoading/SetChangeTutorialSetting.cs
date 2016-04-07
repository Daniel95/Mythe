using UnityEngine;
using System.Collections;

public class SetChangeTutorialSetting : MonoBehaviour {

	public void ChangeTutorialSetting(bool _setting) 
	{
		if (GameObject.FindGameObjectWithTag ("Data"))
        {
            GameObject dataObj = GameObject.FindGameObjectWithTag("Data");
            dataObj.GetComponent<OptionsData>().EnableTutorial = _setting;
            dataObj.GetComponent<SaveLoadPlayerPrefs>().SavePref("EnableTutorial", System.Convert.ToInt32(_setting));
        }
	}
}
