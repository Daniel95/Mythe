using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SavePlayerName : MonoBehaviour
{
    private PlayerData playerData;

    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private SaveLoadPlayerPrefs playerPrefs;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private int minNameLength = 2;

    [SerializeField]
    private int maxNameLength = 20;

    [SerializeField]
    private List<char> notAllowedCharacters;

    private string playerName;

    void Awake() {
        if (GameObject.FindGameObjectWithTag("Data") != null)
            playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
    }

    public void SubmitName(string _input)
    {
        if (_input.Length > minNameLength && _input.Length < maxNameLength && CharactersCheck(_input))
        {
            playerName = _input;

            //save the name in playerName script
            //_plrName.Name = _input;
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
        SaveCurrentName();
        sceneLoader.LoadNewScene("MainMenu");
    }

    public void SaveCurrentName()
    {
        //save the player name in player prefs
        playerPrefs.SavePlayerName(playerName);
        //save the name in playerName script
        playerData.Name = playerName;
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
