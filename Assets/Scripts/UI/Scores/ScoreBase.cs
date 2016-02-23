﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreBase : MonoBehaviour {

    //if we are counting the score or not
    private bool counting = true;

    //the text field we show the player the text in
    protected Text textField;

    //the standard text the textfield contains before we start the program
    protected string standardText;

    void Start()
    {
        //get the textfield on this gameobject and save it in textfield
        textField = GetComponent<Text>();

        //save the standard text, so we can later add the score behind the standard text
        standardText = textField.text;

        //update the textfield when we start so it says: score: 0, instead of score:
        UpdateTextField();
    }

    void Update() {
        if (counting) Count();
    }

    protected virtual void Count() {

    }

    protected virtual void UpdateTextField() {

    }

    public void IncrementScore() {
        if (counting) ChangeValue(1);
    }

    protected virtual void ChangeValue(int change) {
        UpdateTextField();
    }

    public virtual void ResetValue() {
        UpdateTextField();
    }

    public bool Counting {
        set { counting = value; }
    }
}
