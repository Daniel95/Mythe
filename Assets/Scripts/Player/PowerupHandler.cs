using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupHandler : MonoBehaviour {

	private GameObject shieldBubble;
	private GameObject magnetEffect;

	public bool isShieldActive = false;

	public bool IsShieldActive
	{
		get { return isShieldActive; }
	}

	public void addShield()
	{
		shieldBubble = GameObject.Find ("Shield_Bubble");
		if (shieldBubble != null) 
		{
			ObjectPool.instance.PoolObject (shieldBubble);		
		}
		ObjectPool.instance.GetObjectForType ("Shield_Bubble", true);	}

	public void addMagnet()
	{
		magnetEffect = GameObject.Find ("Magnet_Effect");
		if (magnetEffect != null) 
		{
			ObjectPool.instance.PoolObject (magnetEffect);		
		}
		ObjectPool.instance.GetObjectForType ("Magnet_Effect", true);	}
	
}
