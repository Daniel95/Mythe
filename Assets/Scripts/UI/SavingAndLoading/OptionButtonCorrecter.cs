using UnityEngine;
using System.Collections;

public class OptionButtonCorrecter : MonoBehaviour {

	[SerializeField]
	private GameObject objectToEnableCursor;
	[SerializeField]
	private GameObject objectToDisableCursor;

	[SerializeField]
	private GameObject objectToEnableVibration;
	[SerializeField]
	private GameObject objectToDisableVibration;

    [SerializeField]
    private GameObject objectToEnableTutorial;
    [SerializeField]
    private GameObject objectToDisableTutorial;

    [SerializeField]
    private GameObject objectToEnableMusic;
    [SerializeField]
    private GameObject objectToDisableMusic;

    private OptionsData optionsData;

	void Start()
	{
		if (GameObject.FindGameObjectWithTag ("Data")) {
			optionsData = GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ();
		} else 
		{
			Debug.LogError ("No options data found. Did you start from the correct scene?");
		}
		if (optionsData.GetCursor==false) 
		{
			objectToDisableCursor.SetActive (false);
			objectToEnableCursor.SetActive (true);
		}
		if (optionsData.GetVibration==false) 
		{
			objectToDisableVibration.SetActive (false);
			objectToEnableVibration.SetActive (true);
		}
        if (optionsData.GetTutorial == false)
        {
            objectToDisableTutorial.SetActive(false);
            objectToEnableTutorial.SetActive(true);
        }

        if (optionsData.GetMusic == false)
        {
            print("music = "+optionsData.GetMusic);
            objectToDisableMusic.SetActive(false);
            objectToEnableMusic.SetActive(true);
        }

    }


}
