using UnityEngine;
using System.Collections;

public class ShieldBubbleScript : MonoBehaviour {

	private GameObject playerObject;

	private PowerupHandler powerupHandler;

	[SerializeField]
	private float extraTimeAfterHit;

	void Start () {
		playerObject = GameObject.FindGameObjectWithTag (Tags.player);
		powerupHandler = playerObject.GetComponent<PowerupHandler> ();
	}

	void Update () {
		this.transform.position = playerObject.transform.position;
	}

	void StartDestroying(float waitTime)
	{
		StartCoroutine (WaitAndDestroy (waitTime));
	}

	IEnumerator WaitAndDestroy(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		powerupHandler.isShieldActive = false;
		ObjectPool.instance.PoolObject (gameObject);	
	}

	void OnTriggerStay2D(Collider2D _other)
	{
		if (_other.gameObject.GetComponent<InteractableObject> ()) {
			InteractableObject interactableObject = _other.gameObject.GetComponent<InteractableObject> ();
			float _value = interactableObject.HealthValue;
			if (_value < 0) 
			{
				ObjectPool.instance.PoolObject(_other.gameObject);
				StartDestroying (5);
			}
		}
	}
}
