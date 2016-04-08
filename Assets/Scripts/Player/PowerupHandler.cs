using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupHandler : MonoBehaviour {

    //delegate type
    public delegate void PowerupMethods();

    //delegate instance
    public PowerupMethods AddedShield;

    //delegate instance
    public PowerupMethods RemovedShield;

    [SerializeField]
    private ShieldBubbleScript shieldBubble;

    [SerializeField]
    private MagnetAttractor magnetEffect;

    [SerializeField]
    private HealthBar healthBar;

	private bool isShieldActive = false;

	public bool IsShieldActive
	{
        set { isShieldActive = value; }
        get { return isShieldActive; }
	}

    void OnEnable()
    {
        shieldBubble.EndedShieldEffect += ShieldEffectRemoved;
        healthBar.EnterSuperMode += StopMagnet;
        healthBar.PlayerDied += StopMagnet;
    }

    void OnDisable()
    {
        shieldBubble.EndedShieldEffect -= ShieldEffectRemoved;
        healthBar.EnterSuperMode -= StopMagnet;
        healthBar.PlayerDied -= StopMagnet;
    }

    public void AddShield()
	{
        //set the shield powerup active.
        if (!shieldBubble.gameObject.activeSelf)
            shieldBubble.gameObject.SetActive(true);
        //if it is already active, reset it, so it starts again
        else shieldBubble.ResetPowerup();

        //let all subscribed scripts know we just added the shield effect
        if(AddedShield != null)
            AddedShield();
    }

    private void ShieldEffectRemoved() {
        isShieldActive = false;

        //let all subscribed scripts know we just removed the shield effect
        if(RemovedShield != null)
            RemovedShield();
    }

	public void AddMagnet()
	{
        //set the magnet powerup active.
        if (!magnetEffect.gameObject.activeSelf)
            magnetEffect.gameObject.SetActive(true);
        //if it is already active, reset it, so it starts again
        else
            magnetEffect.ResetPowerup();
    }

    void StopMagnet() {
        magnetEffect.gameObject.SetActive(false);
    }
}
