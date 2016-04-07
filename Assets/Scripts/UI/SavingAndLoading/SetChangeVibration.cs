using UnityEngine;
using System.Collections;

public class SetChangeVibration : MonoBehaviour {

	public void ChangeVibrationSetting(bool _setting) 
	{
		if (GameObject.FindGameObjectWithTag ("Data"))
        {
            GameObject dataObj = GameObject.FindGameObjectWithTag("Data");
            dataObj.GetComponent<OptionsData>().EnableVibration = _setting;
            dataObj.GetComponent<SaveLoadPlayerPrefs>().SavePref("EnableVibration", System.Convert.ToInt32(_setting));
        }
	}
}
