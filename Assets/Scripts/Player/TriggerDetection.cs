using UnityEngine;

public class TriggerDetection : MonoBehaviour {

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

            if (interactableObject.gameObject.tag == Tags.shieldPowerUp)
                powerUpHandler.addShield();
            else if (interactableObject.gameObject.tag == Tags.magnetPowerUp)
                powerUpHandler.addMagnet();

            //save the healthvalue of other
            float healthValue = interactableObject.HealthValue;

            //add the value to the healthbar
            healthBar.addValue(healthValue);

            if (healthValue < 0)
                //if the value is negative, shake the screen
                shake.StartShake();
            else
                //if the value is positive, increment score
                pickups.IncrementScore();

            //let the _other object know that it has been touched so it can play its animation
            interactableObject.Touched();
        }
    }

    //this triggerenter is for the player so it can interact with other objects.
    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.gameObject.GetComponent<InteractableObject>()) {


        }
    }
}
