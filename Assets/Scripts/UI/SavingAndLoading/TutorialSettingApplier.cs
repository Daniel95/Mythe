using UnityEngine;
using System.Collections;

public class TutorialSettingApplier : MonoBehaviour {

	private OptionsData optionsData;

	[SerializeField]
	private GameObject tutorialHolder;

	void Start()
	{
		if (GameObject.FindGameObjectWithTag ("Data")) {
			optionsData = GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ();
		}
		if (optionsData.GetTutorial == false) 
		{
			tutorialHolder.GetComponent<TutorialUnlocker> ().enabled = false;
		}
		if (optionsData.GetTutorial == true) 
		{
			tutorialHolder.GetComponent<TutorialUnlocker> ().enabled = true;
		}

	}
}
