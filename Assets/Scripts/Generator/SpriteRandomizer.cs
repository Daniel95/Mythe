using UnityEngine;
using System.Collections;

public class SpriteRandomizer : MonoBehaviour {

	[SerializeField]
	private Sprite[] spriteArray;
	private SpriteRenderer spriteRenderer;
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

    public void Randomize() {
        spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
    }

	void OnEnable()
	{
        Randomize();
	}
}