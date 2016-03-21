using UnityEngine;
using System.Collections;

public class ShieldBubbleScript : MonoBehaviour {

	private bool canIBeDestroyed = false;

	private CameraShake shake;

	private GameObject playerObject;

	private PowerupHandler powerupHandler;
	private SpriteRenderer spriteRender;

	[SerializeField]
	private float shrinkRate;

	private Vector3 startVector;

	private bool shouldIShrink;


	void Start () {
		startVector = transform.localScale;
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
		powerupHandler = playerObject.GetComponent<PowerupHandler> ();
		shake = GameObject.Find ("MainCamera").GetComponent<CameraShake> ();
	}

	void OnEnable()
	{
		StartCoroutine (WaitAndMakeDestroyable (3));

	}

	void Update () {
		this.transform.position = playerObject.transform.position;
		if (transform.localScale.x <= 0) {
			shouldIShrink = false;
			powerupHandler.isShieldActive = false;
			transform.localScale = startVector;
			ObjectPool.instance.PoolObject (gameObject);
		}
		if (shouldIShrink) 
		{
			transform.localScale -= new Vector3(shrinkRate, shrinkRate, 0);
		}
	}

	void StartDestroying()
	{
		shouldIShrink = true;
	}

	IEnumerator WaitAndMakeDestroyable(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		canIBeDestroyed = true;
	}

	void OnTriggerEnter2D(Collider2D _other)
	{
		if (_other.gameObject.GetComponent<InteractableObject> ()) {
			InteractableObject interactableObject = _other.gameObject.GetComponent<InteractableObject> ();
			float _value = interactableObject.HealthValue;
			if (_value < 0) 
			{
				shake.StartShake();
				ObjectPool.instance.PoolObject(_other.gameObject);
				if(canIBeDestroyed)
				StartDestroying ();
			}
		}
	}
}
