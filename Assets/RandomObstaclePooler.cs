using UnityEngine;
using System.Collections;

public class RandomObstaclePooler : MonoBehaviour {

	[SerializeField]
	private string[] objectToSpawnNames;

	private bool trueActive = false;

	void OnEnable()
	{
		if (trueActive) {
            StartCoroutine(SpawnObject());

		} else {
			trueActive = true;
		}
	}

    private IEnumerator SpawnObject()
    {
        yield return new WaitForFixedUpdate();
        GameObject spawnedObject = ObjectPool.instance.GetObjectForType(objectToSpawnNames[Random.Range(0, objectToSpawnNames.Length)], true);
        spawnedObject.transform.position = this.transform.position;
        ObjectPool.instance.PoolObject(gameObject);
    }
}
