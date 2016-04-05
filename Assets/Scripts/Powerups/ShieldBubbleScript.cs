using UnityEngine;
using System.Collections;

public class ShieldBubbleScript : MonoBehaviour {

    //delegate type
    public delegate void ShieldBubbleState();

    //delegate instance
    public ShieldBubbleState EndedShieldEffect;

    private bool canIBeDestroyed = false;

	[SerializeField]
	private float duration = 3;

    [SerializeField]
	private CameraShake shake;

    [SerializeField]
	private Transform playerObject;

	private SpriteRenderer spriteRender;

	[SerializeField]
	private float shrinkRate;

	private Vector3 startVector;

	private bool shouldIShrink;

	void Start () {
		startVector = transform.localScale;
	}

	void OnEnable()
	{
		StartCoroutine ("WaitAndMakeDestroyable",duration);
	}

	void FixedUpdate () {
		transform.position = playerObject.position;

		if (shouldIShrink) 
		{
			transform.localScale -= new Vector3(shrinkRate, shrinkRate, 0);
			canIBeDestroyed = false;

            if (transform.localScale.x <= 0)
            {
                shouldIShrink = false;

                transform.localScale = startVector;

                //let the poweruphandler know the shield effect has just ended
                if(EndedShieldEffect != null)
                    EndedShieldEffect();

                gameObject.SetActive(false);
            }
        }
	}

    public void ResetPowerup() {
        
		StopCoroutine("WaitAndMakeDestroyable");
		StartCoroutine ("WaitAndMakeDestroyable",duration);
        shouldIShrink = false;
        transform.localScale = startVector;
		gameObject.SetActive(false);
		gameObject.SetActive(true);
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
                    shouldIShrink = true;
            }
		}
	}
}
