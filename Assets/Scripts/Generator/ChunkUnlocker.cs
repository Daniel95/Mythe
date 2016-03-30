using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ChunkUnlocker : MonoBehaviour {

	[SerializeField]
	private ChunkHolder chunkHolder;

	[SerializeField]
	private PlayerDistance playerDistance;

	[SerializeField]
	private List<int> unlockValues;

    [SerializeField]
    private List<string> introChunks;

    [SerializeField]
    private List<string> easyChunks;

    [SerializeField]
    private List<string> mediumChunks;

    [SerializeField]
    private List<string> hardChunks;

    [SerializeField]
    private List<string> superHardChunks;

    [SerializeField]
    private List<string> extremeChunks;

    void Start()
    {
        StartCoroutine(Unlocking());
    }
	public void UnlockChunk(string chunkToUnlock)
	{
		//Use this to force unlock new chunks.
		chunkHolder.LoadChunk (chunkToUnlock);
	}
    IEnumerator Unlocking()
    {
        for(int i = 0; i<introChunks.Count; i++)
        {
            UnlockChunk(introChunks[i]);
        }

        while (playerDistance.Distance < 1000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < easyChunks.Count; i++)
        {
            UnlockChunk(easyChunks[i]);
        }

        while (playerDistance.Distance < 2000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < mediumChunks.Count; i++)
        {
            UnlockChunk(mediumChunks[i]);
        }

        while (playerDistance.Distance < 3000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < hardChunks.Count; i++)
        {
            UnlockChunk(hardChunks[i]);
        }

        while (playerDistance.Distance < 4000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < superHardChunks.Count; i++)
        {
            UnlockChunk(superHardChunks[i]);
        }

        while (playerDistance.Distance < 5000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i <extremeChunks.Count; i++)
        {
            UnlockChunk(extremeChunks[i]);
        }



    }
}
