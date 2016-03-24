using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectableObject : MonoBehaviour {

    private int objectNumber;

    public void SetObjectNumber(int _objNumber) {
        objectNumber = _objNumber;
        GetComponent<Image>().sprite = ObjectsInNodeInfo.Sprites[objectNumber];
    }

    public void ChooseObject() {
        GetComponentInParent<ObjectSelection>().ChangeObject(objectNumber);
    }

    public int ObjectNumber {
        set { objectNumber = value; }
    }
}
