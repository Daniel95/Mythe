using UnityEngine;
using System.Collections;

public class PoolMySelf : MonoBehaviour {

	private int timer = 0;

	[SerializeField]
	private int timerEnd = 20;

	void OnEnable()
	{
		timer = 0;
	}
	void Update () {
		timer++;
		if (timer >= timerEnd) {
			//This puts the object pack into the object pool.
			PoolMe();
		}
	}

	public void PoolMe()
	{
		ObjectPool.instance.PoolObject (gameObject);
	}
}
