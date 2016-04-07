using UnityEngine;
using System.Collections;

public class TriggerDetection : MonoBehaviour {

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private PlayerPickups pickups;

    [SerializeField]
    private CameraShake shake;

    [SerializeField]
    private PowerupHandler powerUpHandler;

    private InteractableObject interactableObject;

	private bool hurtable = true;

	[SerializeField]
	private float hurtableCooldown = 1;

    private bool playWaterSound;

	private OptionsData optionsData;

	void Start()
	{
		if (GameObject.FindGameObjectWithTag ("Data")) {
			optionsData = GameObject.FindGameObjectWithTag ("Data").GetComponent<OptionsData> ();
		}
	}
    void OnCollisionEnter2D(Collision2D _other) {
        HandleCollisionEnter(_other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D _other) {
        HandleCollisionEnter(_other.gameObject);
    }

    private void HandleCollisionEnter(GameObject _other) {
        if (_other.gameObject.GetComponent<InteractableObject>())
		{
            //save the script of _other, in the variable
            interactableObject = _other.gameObject.GetComponent<InteractableObject>();

			if (interactableObject.IsEnabled) {
				if (interactableObject.transform.CompareTag(Tags.shieldPowerUp)) {
					powerUpHandler.AddShield ();
					audioSource.PlayOneShot (audioClip);
				} else if (interactableObject.transform.CompareTag(Tags.magnetPowerUp)) {
					powerUpHandler.AddMagnet ();
					audioSource.PlayOneShot (audioClip);
				}

				//save the healthvalue of other
				float healthValue = interactableObject.HealthValue;

				//add the value to the healthbar
				if (healthValue < 0) 
				{
					if(hurtable)
					{
					    healthBar.addValue (healthValue);
					    audioSource.PlayOneShot (audioClip);
					    //if the value is negative, shake the screen
					    shake.StartShake ();
						if (optionsData != null && optionsData.GetVibration) 
						{
							Handheld.Vibrate ();
						}
                        MakeUnhurtable();
					
					}
				} else if (healthValue > 0) { //if the value is positive, increment score
					pickups.IncrementScore ();
					healthBar.addValue (healthValue);

                    //only play water pickup sound when supermodeIsOn is false
                    if (!healthBar.SuperModeIsOn)
                    {
                        audioSource.pitch = Random.Range(0.75F, 1.25F);
                        audioSource.PlayOneShot(audioClip);
                    }
				}
				//let the _other object know that it has been touched so it can play its animation
				interactableObject.Touched ();
			}
        }

    }

	public void MakeUnhurtable()
	{
		hurtable = false;
		StartCoroutine (HurtableCoolDownTimer (hurtableCooldown));
	}

	IEnumerator HurtableCoolDownTimer(float cooldown)
	{
		yield return new WaitForSeconds (cooldown);
		hurtable = true;
	}

	public bool Hurtable {
		get { return hurtable; }
	}
}
