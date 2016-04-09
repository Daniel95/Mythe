using UnityEngine;
using System.Collections;

public class TriggerDetection : MonoBehaviour {

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip pickupClip;

    [SerializeField]
    private AudioClip collisionClip;

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

    private bool optionMusic = true;
    private bool optionVibration = true;

    void Start()
	{
		if (GameObject.FindGameObjectWithTag ("Data")) {
            optionMusic = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>().GetMusic;
            optionVibration = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>().GetVibration;
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
                    if(optionMusic)
                    {
                        audioSource.PlayOneShot(pickupClip);
                    }
					
				} else if (interactableObject.transform.CompareTag(Tags.magnetPowerUp)) {
					powerUpHandler.AddMagnet ();
                    if (optionMusic)
                    {
                        audioSource.PlayOneShot(pickupClip);
                    }
				}

				//save the healthvalue of other
				float healthValue = interactableObject.HealthValue;

				//add the value to the healthbar
				if (healthValue < 0) 
				{
					if(hurtable)
					{
					    healthBar.addValue (healthValue);
                        GetHitEffect();
					}
				} else if (healthValue > 0) { //if the value is positive, increment score
					pickups.IncrementScore ();
					healthBar.addValue (healthValue);

                    //only play water pickup sound when supermodeIsOn is false
                    if (!healthBar.SuperModeIsOn && optionMusic)
                    {
                        audioSource.pitch = Random.Range(0.75F, 1.25F);
                        audioSource.PlayOneShot(pickupClip);
                    }
				}
				//let the _other object know that it has been touched so it can play its animation
				interactableObject.Touched ();
			}
        }

    }

    public void GetHitEffect() {
        MakeUnhurtable();

        if (optionMusic)
        {
            audioSource.PlayOneShot(collisionClip);
        }

        if (optionVibration)
        {
            Handheld.Vibrate();
        }

        //shake the screen
        shake.StartShake();
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
