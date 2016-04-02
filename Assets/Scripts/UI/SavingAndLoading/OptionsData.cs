using UnityEngine;
using System.Collections;

public class OptionsData : MonoBehaviour {

    private bool changeName;

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
}
