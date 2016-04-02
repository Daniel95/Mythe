using UnityEngine;
using System.Collections;

public class SetChangeNameOption : MonoBehaviour {

    public void SetChangeNameTrue() {
        if (GameObject.FindGameObjectWithTag("Data"))
            GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>().ChangeName = true;
    }
}
