using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private string playerName;

    public string Name
    {
        get { return playerName; }
        set { playerName = value; }
    }
}
