using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private string _playerName;

    public string Name
    {
        get { return _playerName; }
        set { _playerName = value; }
    }
}
