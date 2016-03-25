﻿using UnityEngine;
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
    private List<GameObject> selectionOptions;

    private List<Node> selection = new List<Node>();

    void Start() {
        for (int i = 0; i < selectionOptions.Count; i++)
        {
            selectionOptions[i].SetActive(false);
            //the object number is its number in the list
            selectionOptions[i].GetComponent<SelectableObject>().SetObjectNumber(i);
        }
    }

    //public void StartMenu(int _x, int _y)
    public void StartMenu(Node _node)
    {
        //save the x,y values of the node
        selection.Add(_node);

        //show the selectableObjects
        SetSelectionState(true);
    }

    public void ChangeObject(int _objectNumber)
    {
        for (int i = 0; i < selection.Count; i++) {
            //save every selected object
            chunkEditor.EditChunk(selection[i].X, selection[i].Y, _objectNumber);
        }

        //clear the list
        selection.Clear();

        //send the new objectNumber to the Node we are changin
        if(DoneSelecting != null)
            DoneSelecting(_objectNumber);

        SetSelectionState(false);
    }

    private void SetSelectionState(bool _state) {
        //turn all the selectableObjects on or off
        for (int i = 0; i < selectionOptions.Count; i++)
        {
            selectionOptions[i].SetActive(_state);
        }
    }
}
