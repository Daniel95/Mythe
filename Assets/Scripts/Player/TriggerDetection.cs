using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private PlayerPickups pickups;

    [SerializeField]
    private CameraShake shake;

    //this triggerenter is for the player so it can interact with other objects.
    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.gameObject.GetComponent<InteractableObject>()) {
            InteractableObject interactableObject = _other.gameObject.GetComponent<InteractableObject>();

            if (interactableObject.DestroyOnTouch)
            {
                ObjectPool.instance.PoolObject(_other.gameObject);
            }
            float _value = interactableObject.Value;

            healthBar.addValue(_value);
            if (_value < 0)
            {
                shake.StartShake();
				Handheld.Vibrate ();
            }
            else {
                pickups.IncrementScore();
            }
        }
    }
}
