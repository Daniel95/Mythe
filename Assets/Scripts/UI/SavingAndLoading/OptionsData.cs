using UnityEngine;
using System.Collections;

public class OptionsData : MonoBehaviour {

	private bool changeName;

	private bool enableTutorial = true;
	private bool enableVibration = true;
    private bool enableCursor = true;
    private bool enableMusic = true;

    public bool CheckIfChangingName() {
		if (changeName)
		{
			changeName = false;
			return true;
		}
		else
			return false;
	}

	public bool ChangeName {
		set { changeName = value; }
	}

	public bool GetTutorial
	{
		get
		{
			return enableTutorial;
		}
	}

	public bool GetVibration
	{
		get
		{
			return enableVibration;
		}
	}

    public bool GetCursor
    {
        get
        {
            return enableCursor;
        }
    }

    public bool GetMusic
    {
        get
        {
            return enableMusic;
        }
    }


    public bool EnableTutorial {
		set { enableTutorial = value; }
	}

	public bool EnableVibration {
		set { enableVibration = value; }
	}

    public bool EnableCursor
    {
        set { enableCursor = value; }
    }
    public bool EnableMusic
    {
        set { enableMusic = value; }
    }
}
