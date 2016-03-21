using UnityEngine;
using System.Collections.Generic;

public class ChunkUnlocker : MonoBehaviour {

	[SerializeField]
	private ChunkHolder chunkHolder;

	[SerializeField]
	private PlayerDistance playerDistance;

	public List<string> notUnlockedChunks;

    private List<string> alreadyUnlockedChunks;

    private List<int> alreadyUnlockedValues;

	[SerializeField]
	private List<int> unlockValues;

	public void UnlockChunks()
	{
		int distance = playerDistance.Distance;
		for(int i = 0; i<unlockValues.Count; i++) 
		{
			if (distance >= unlockValues[i]) 
			{
				unlockValues.Remove (unlockValues[i]);
                alreadyUnlockedValues.Add(unlockValues[i]);
				chunkHolder.LoadChunk (notUnlockedChunks [i]);
				notUnlockedChunks.Remove (notUnlockedChunks [i]);
                alreadyUnlockedValues.Add(alreadyUnlockedValues[i]);
			}
		}
	}

    public void RelockChunks()
    {
        for (int i = 0; i < this.alreadyUnlockedChunks.Count; i++)
        {
            unlockValues.Add(alreadyUnlockedValues[i]);
            notUnlockedChunks.Add(alreadyUnlockedChunks[i]);
            alreadyUnlockedChunks.Remove(alreadyUnlockedChunks[i]);
            alreadyUnlockedValues.Remove(alreadyUnlockedValues[i]);
        }
    }

}
