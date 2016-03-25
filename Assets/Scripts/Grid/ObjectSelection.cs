using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSelection : MonoBehaviour
{
    //delegate type
    public delegate void SelectObjectStatus(int _itemNumber);

    //delegate instance
    public SelectObjectStatus DoneSelecting;

    [SerializeField]
    private ChunkEditor chunkEditor;

    [SerializeField]
    private List<GameObject> selection;

    private int selectedX;

    private int selectedY;

    void Start() {
        for (int i = 0; i < selection.Count; i++)
        {
            selection[i].SetActive(false);
            //the object number is its number in the list
            selection[i].GetComponent<SelectableObject>().SetObjectNumber(i);
        }
    }

    public void StartMenu(int _x, int _y)
    {
        //save the x,y values of the node
        selectedX = _x;
        selectedY = _y;

        //show the selectableObjects
        SetSelectionState(true);
    }

    public void ChangeObject(int _objectNumber)
    {
        //send the values x,y values of the node, and the new object number to the editChunk script
        chunkEditor.EditChunk(selectedX, selectedY, _objectNumber);

        //send the new objectNumber to the Node we are changin
        if(DoneSelecting != null)
            DoneSelecting(_objectNumber);

        SetSelectionState(false);
    }

    private void SetSelectionState(bool _state) {
        //turn all the selectableObjects on or off
        for (int i = 0; i < selection.Count; i++)
        {
            selection[i].SetActive(_state);
        }
    }
}
