using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private List<char> notAllowedCharacters;

    void Start()
    {
        //we cannot click on the submit button until be entered our name
        submitButton.interactable = false;
    }

    public void SubmitName(string _input)
    {
        if (_input.Length > minNameLength && _input.Length < maxNameLength && CharactersCheck(_input))
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

    private bool CharactersCheck(string _input) {

        for (int i = 0; i < _input.Length; i++) {
            for (int b = 0; b < notAllowedCharacters.Count; b++) {
                if (_input.ToCharArray()[i] == notAllowedCharacters[b])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
