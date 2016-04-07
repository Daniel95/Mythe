using UnityEngine;
using System.Collections;

public class SetChangeCursorSetting : MonoBehaviour {

	public void SetChangeCursor(bool _setting) 
	{
        if (GameObject.FindGameObjectWithTag("Data"))
        {
            GameObject dataObj = GameObject.FindGameObjectWithTag("Data");
            dataObj.GetComponent<OptionsData>().EnableCursor = _setting;
            dataObj.GetComponent<SaveLoadPlayerPrefs>().SavePref("EnableCursor", System.Convert.ToInt32(_setting));
        }
    }
}
