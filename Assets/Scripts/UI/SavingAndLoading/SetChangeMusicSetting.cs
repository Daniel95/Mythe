using UnityEngine;
using System.Collections;

public class SetChangeMusicSetting : MonoBehaviour {

    public void ChangeMusicSetting(bool _setting)
    {
        if (GameObject.FindGameObjectWithTag("Data"))
        {
            GameObject dataObj = GameObject.FindGameObjectWithTag("Data");
            dataObj.GetComponent<OptionsData>().EnableMusic = _setting;
            dataObj.GetComponent<SaveLoadOptions>().SavePref("EnableMusic", System.Convert.ToInt32(_setting));
        }
    }
}
