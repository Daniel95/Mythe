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
    private PlayerData playerData;

    [SerializeField]
    private SaveLoadPlayerPrefs playerPrefs;

    void Awake() {
        welcomeText = welcomeTextObj.GetComponent<DynamicText>();

        if (GameObject.FindGameObjectWithTag("Data")) {
            playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>(); 
        }
    }

    void OnEnable()
    {
        playerPrefs.LoadedPlayerName += SetPlayerName;
        playerPrefs.NoPlayerNameFound += EnableNameInput;
    }

    void OnDisable()
    {
        playerPrefs.LoadedPlayerName -= SetPlayerName;
        playerPrefs.NoPlayerNameFound -= EnableNameInput;
    }

    public void SetPlayerName(string _playerName) {
        inputFieldObj.SetActive(false);
        submitButton.SetActive(false);
        playerData.Name = _playerName;
        welcomeText.AddString(_playerName);
    }

    public void EnableNameInput() {
        welcomeTextObj.SetActive(false);
        continueButton.SetActive(false);
    }
}
