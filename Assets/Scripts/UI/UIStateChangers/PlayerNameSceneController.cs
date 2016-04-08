using UnityEngine;
using System.Collections;

public class PlayerNameSceneController : MonoBehaviour {

    [SerializeField]
    private GameObject inputFieldObj;

    [SerializeField]
    private GameObject welcomeTextObj;

    private DynamicText welcomeText;

    [SerializeField]
    private GameObject submitButton;

    [SerializeField]
    private GameObject continueButton;

    [SerializeField]
    private SaveLoadPlayerName saveLoadPlayerName;

    private PlayerData playerData;

    void Awake() {
        welcomeText = welcomeTextObj.GetComponent<DynamicText>();

        if (GameObject.FindGameObjectWithTag("Data")) {
            playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        }
    }

    void OnEnable()
    {
        saveLoadPlayerName.LoadedPlayerName += SetPlayerName;
        saveLoadPlayerName.NoPlayerNameFound += EnableNameInput;
    }

    void OnDisable()
    {
        saveLoadPlayerName.LoadedPlayerName -= SetPlayerName;
        saveLoadPlayerName.NoPlayerNameFound -= EnableNameInput;
    }

    private void SetPlayerName(string _playerName) {
        //assign the saved name, and allow the player to continue
        inputFieldObj.SetActive(false);
        submitButton.SetActive(false);
        playerData.Name = _playerName;
        welcomeText.AddString(_playerName);
    }

    private void EnableNameInput() {
        //make the player enter a new name
        welcomeTextObj.SetActive(false);
        continueButton.SetActive(false);
    }
}
