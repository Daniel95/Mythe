﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavePlayerName : MonoBehaviour
{
    [SerializeField]
    private PlayerName _plrName;

    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private int minNameLength = 2;

    [SerializeField]
    private int maxNameLength = 20;

    void Start()
    {
        //we cannot click on the submit button until be entered our name
        submitButton.interactable = false;
    }

    public void SubmitName(string _input)
    {
        if (_input.Length > minNameLength && _input.Length < maxNameLength)
        {
            //save the name in playerName script
            _plrName.Name = _input;
            //the player can click the button to continue
            submitButton.interactable = true;
            //the player can hit enter to continue
            StartCoroutine(WaitForEnter());
        }
        else
        {
            //the player can no longer interact with submit button to continue
            submitButton.interactable = false;
            //the player can no longer hit enter to continue
            StopCoroutine(WaitForEnter());
        }
    }

    private IEnumerator WaitForEnter()
    {
        //when we get the required input, we execute nextScene
        while (!Input.GetButton("Submit"))
        {
            yield return null;
        }
        sceneLoader.loadNextScene();
    }
}
