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

	private bool isShieldActive = false;

	public bool IsShieldActive
	{
        set { isShieldActive = value; }
        get { return isShieldActive; }
	}

    void OnEnable()
    {
        shieldBubble.EndedShieldEffect += ShieldEffectRemoved;
    }

    void OnDisable()
    {
        shieldBubble.EndedShieldEffect -= ShieldEffectRemoved;
    }

    public void AddShield()
	{
        /*
		shieldBubble = GameObject.Find ("Shield_Bubble");
		if (shieldBubble != null) 
		{
			ObjectPool.instance.PoolObject (shieldBubble);		
		}
		ObjectPool.instance.GetObjectForType ("Shield_Bubble", true);
        */
        shieldBubble.gameObject.SetActive(true);

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
        /*
		magnetEffect = GameObject.Find ("Magnet_Effect");
		if (magnetEffect != null) 
		{
			ObjectPool.instance.PoolObject (magnetEffect);		
		}
		ObjectPool.instance.GetObjectForType ("Magnet_Effect", true);
        */
        magnetEffect.gameObject.SetActive(true);
    }


}
