using UnityEngine;

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
			if (interactableObject.isEnabled) {
				if (interactableObject.gameObject.tag == Tags.shieldPowerUp) {
					powerUpHandler.addShield ();
					audioSource.PlayOneShot (audioClip);
				} else if (interactableObject.gameObject.tag == Tags.magnetPowerUp) {
					powerUpHandler.addMagnet ();
					audioSource.PlayOneShot (audioClip);
				}
               

				//save the healthvalue of other
				float healthValue = interactableObject.HealthValue;

				//add the value to the healthbar
				healthBar.addValue (healthValue);

				if (healthValue < 0) {
					audioSource.PlayOneShot (audioClip);
					//if the value is negative, shake the screen
					shake.StartShake ();
				} else if (healthValue > 0) { //if the value is positive, increment score
					pickups.IncrementScore ();
					audioSource.pitch = Random.Range (0.75F, 1.25F);
					audioSource.PlayOneShot (audioClip);
				}
				//let the _other object know that it has been touched so it can play its animation
				interactableObject.Touched ();
			}
        }
    }
}
