using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private string playerName;

    public string Name
    {
        get { return playerName; }
        set { playerName = value; }
    }

    private string playerId;

    public string Id
    {
        get { return playerId; }
        set { playerId = value; }
    }

    void Start() {
        playerId = SystemInfo.deviceUniqueIdentifier;
    }
}
