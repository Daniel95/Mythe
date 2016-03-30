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

    //beginning of game.
    private List<string> introChunks 
        = new List<string> {
        "100001100001110301100001100001100001100001100001103011100001100001100001",
        "000000103001100001100301100001100001000000",
        "000000000000030100000010000001000000001030010000100000",
        };

    //after supermode has been introduced.
    private List<string> easyChunks 
        = new List<string> {
        "110011000000000000",
        "000000003000200000000000111100000000",
        "010000000000030000000103000100100000000000",
        "000000000000001000010000100301000010000100001030001030000100003010100010010010010010010010100001",
        "000000000000030000000100000000000000010001000000100010000000010001000300100000000000000010000000",
        };

    //after shield introduce chunk.
    private List<string> mediumChunks
        = new List<string> {
        "000000000020000000003000000300020000000000",
        "000000000000000000131030131000000000000000000000000000030131000131000000000000000000",
        "010000000000030000000103000100100000000000",
        "000000301111000000",
        "000000111103000000",
        "000000000000111111111111000000005500000000010010100001"
        };

    //after magnet has been introduced. 
    private List<string> hardChunks
    = new List<string> {
        "000000041150000000",
        "000000000000110000310000110011000013000011000000000000004000000000000000",
        "000000000300000000000000000007000000000000000300000000000000700000000000000000"
        };

    //after side walk enemy has been introduced
    private List<string> superHardChunks
    = new List<string> {
        "000300000000600000000006600000000006600000003006000000000000",
        "000000000000000000000000000030000000060003000000000030000000000000000000000000"
        };

    //this is when every new object has been introduced! so go nuts!
    private List<string> extremeChunks
    = new List<string>
    {

    };

    private List<string> almostImpossibleChunks
    = new List<string>
    {

    };

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
        for (int i = 0; i < extremeChunks.Count; i++)
        {
            UnlockChunk(extremeChunks[i]);
        }

        while (playerDistance.Distance < 10000f)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < almostImpossibleChunks.Count; i++)
        {
            UnlockChunk(almostImpossibleChunks[i]);
        }



    }
}
