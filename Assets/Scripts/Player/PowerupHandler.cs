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
        healthBar.EnterSuperMode += StopMagnetOnSuperMode;
    }

    void OnDisable()
    {
        shieldBubble.EndedShieldEffect -= ShieldEffectRemoved;
        healthBar.EnterSuperMode -= StopMagnetOnSuperMode;
    }

    public void AddShield()
	{
        if (!shieldBubble.gameObject.activeSelf)
            shieldBubble.gameObject.SetActive(true);
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
        if (!magnetEffect.gameObject.activeSelf)
            magnetEffect.gameObject.SetActive(true);
        else
            magnetEffect.ResetPowerup();
    }

    void StopMagnetOnSuperMode() {
        magnetEffect.gameObject.SetActive(false);
    }
}
