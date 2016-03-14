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

	public void UnlockChunks()
	{
		int distance = playerDistance.Distance;
		for(int i = 0; i<unlockValues.Count; i++) 
		{
			if (distance >= unlockValues[i]) 
			{
				unlockValues.Remove (unlockValues[i]);
				chunkHolder.LoadChunk (notUnlockedChunks [i]);
				notUnlockedChunks.Remove (notUnlockedChunks [i]);
			}
		}
	}
}
