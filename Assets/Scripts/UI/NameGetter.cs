using UnityEngine;
using UnityEngine.UI;

public class NameGetter : MonoBehaviour {
	[SerializeField]
	private Text nameText;
	[SerializeField]
	private PlayerData playerData;
	void Start () 
	{
		nameText.text = playerData.Name;
	}
}
