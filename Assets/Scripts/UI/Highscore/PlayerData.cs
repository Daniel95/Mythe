using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private string playerName = "name";

    public string Name
    {
        get { return playerName; }
        set { playerName = value; }
    }
}
