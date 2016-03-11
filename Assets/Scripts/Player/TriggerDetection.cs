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

    //this triggerenter is for the player so it can interact with other objects.
    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.GetComponent<InteractableObject>()) {
            InteractableObject interactableObject = _other.gameObject.GetComponent<InteractableObject>();
			float _value = interactableObject.Value;
			if (interactableObject.gameObject.tag == Tags.shieldPowerUp) 
			{
				powerUpHandler.addShield ();
			}
				
			if (interactableObject.gameObject.tag == Tags.magnetPowerUp) 
			{
				powerUpHandler.addMagnet ();
			}
            if (interactableObject.DestroyOnTouch)
            {
                ObjectPool.instance.PoolObject(_other.gameObject);
            }
            healthBar.addValue(_value);
            if (_value < 0)
            {
                shake.StartShake();
            }
            else {
                pickups.IncrementScore();
            }

        }
    }
}
