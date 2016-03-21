using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private string playerName;

    public string Name
    {
        get { return playerName; }
        set { playerName = value; }
    }
}
