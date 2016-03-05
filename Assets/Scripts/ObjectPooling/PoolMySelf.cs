using UnityEngine;

public class PoolMySelf : MonoBehaviour {

    [SerializeField]
    private int yDestroyPosition = -6;

	void Update () {
		if (transform.position.y < yDestroyPosition) {
			//This puts the object pack into the object pool.
			PoolMe();
		}
	}

	public void PoolMe()
	{
		ObjectPool.instance.PoolObject (gameObject);
	}
}
