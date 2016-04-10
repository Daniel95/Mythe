using UnityEngine;
using System.Collections;

public class SpriteRandomiser : MonoBehaviour {

	[SerializeField]
	private Sprite[] spriteArray;
	private SpriteRenderer spriteRenderer;
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void OnEnable()
	{
		spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
	}
}