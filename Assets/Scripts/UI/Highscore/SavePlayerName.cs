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
    private LoadData loadData;

    [SerializeField]
    private SaveData saveData;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private int minNameLength = 2;

    [SerializeField]
    private int maxNameLength = 20;

    [SerializeField]
    private List<char> notAllowedCharacters;

    [SerializeField]
    private GameObject NameNotUnique;

    private string playerName;

    void Awake() {
        NameNotUnique.SetActive(false);

        if (GameObject.FindGameObjectWithTag("Data") != null)
            playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();

        submitButton.interactable = false;
    }

    void OnEnable()
    {
        loadData.FinishedLoading += CheckNameUnique;
    }

    void OnDisable()
    {
        loadData.FinishedLoading -= CheckNameUnique;
    }

    public void SubmitName(string _input)
    {
        //make sure there are no caps
        _input = _input.ToLower();

        if (_input.Length > minNameLength && _input.Length < maxNameLength && CharactersCheck(_input))
        {
            NameNotUnique.SetActive(false);

            //save the input
            playerName = _input;

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
        AskForNames();
    }

    public void AskForNames() {
        loadData.Load("distance");
    }

    private void CheckNameUnique(string _values, string _dataType)
    {
        bool nameIsUnique = true;

        string[] lines = _values.Trim().Split('\n');

        foreach (string text in lines)
        {
            //split the names and scores in a string array
            string[] seperatedLines = text.Split('_');

            //check each name and see if ours is the same
            if (seperatedLines[0] == playerName)
                nameIsUnique = false;
        }

        if (nameIsUnique)
            SaveName();
        else
            NameNotUnique.SetActive(true);
    }

    private void SaveName() {
        saveData.ReplaceName(playerData.Name, playerName);

        //save the player name in player prefs
        playerPrefs.SavePlayerName(playerName);

        //save the name in playerName script
        playerData.Name = playerName;

        sceneLoader.LoadNewScene("MainMenu");
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
