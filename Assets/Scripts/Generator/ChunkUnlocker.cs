using UnityEngine;
using System.Collections.Generic;

public class ChunkUnlocker : MonoBehaviour {

	[SerializeField]
	private ChunkHolder chunkHolder;

	[SerializeField]
	private PlayerDistance playerDistance;
	public List<string> notUnlockedChunks;

	[SerializeField]
	private List<int> unlockValues;

	[SerializeField]
	private List<int> ExtraChunks;


	public void UnlockChunk(string chunkToUnlock)
	{
		//Use this to force unlock new chunks.
		chunkHolder.LoadChunk (chunkToUnlock);
	}

	public void UnlockChunksWithDistance()
	{
		//This function is called constantly and will unlock new chunks based on score.
		int distance = playerDistance.Distance;
		for(int i = 0; i<unlockValues.Count; i++) 
		{
			if (distance >= unlockValues[i]) 
			{
				//Removes the unlock values based on distance.
				unlockValues.Remove (unlockValues[i]);
				notUnlockedChunks.Remove (notUnlockedChunks [i]);
				//Then unlocks 
				UnlockChunk (notUnlockedChunks[i]);

			}
		}
	}
}
