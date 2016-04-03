using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ChunkUnlocker : MonoBehaviour {

	[SerializeField]
	private ChunkHolder chunkHolder;

	[SerializeField]
	private PlayerDistance playerDistance;

	[SerializeField]
	private int[] unlockSeconds;

    private List<List<string>> chunksToUnlock = new List<List<string>>();

    private int counter;

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
        "000000000000000301020000000000",
        "000000000300100000000020000000003000000000010000000030000000",
        "000000030000000000000200000000001000000000000030030000000000",
        "000000000000000300000001001000000030000000000000",
        "000000000030030000000000001000200000000000000000",
        "000000000000000100000010000000003010000001000000",
        "000000001000000000000300000000000010000000000000",
        "000000000020030000000010000000000000010030000000",
        };

    //after shield introduce chunk.
    private List<string> mediumChunks
        = new List<string> {
        "000000000020000000003000000300020000000000",
        "000000000000000000131030131000000000000000000000000000030131000131000000000000000000",
        "010000000000030000000103000100100000000000",
        "000000301111000000",
        "000000111103000000",
        "000000000000111111111111000000000500000000010010100001",
        "000000001030000100003000000000",
        "000000003000000000020002000000",
        "000010010000100000003020000000",
        "000000000001000000013000000010000000000000000000000310000000010000000000",
        "000000001000001000000030000000000200000000100020000000000000",
        "000000000030010000000010000000000010010000000030100000000100300000000001010000",
        "000000130000000200030000000000",
        };

    //after magnet has been introduced. 
    private List<string> hardChunks
    = new List<string> {
        "000000041150000000",
        "000000000000110000310000110011000013000011000000000000004000000000000000",
        "000000000300000000000000000007000000000000000300000000000000700000000000000000",
        "000000200000000020000000030000000000001030000000100100000000000001010000000010000050000100000001030000000000",
        "000000020000000000200130000000000000100010000000010030000000000020030000000002010000000000000001200010000000",
        };

    //after side walk enemy has been introduced
    private List<string> superHardChunks
    = new List<string> {
        "000300000000600000000006600000000006600000003006000000000000",
        "000000000000000000000000000030000000060003000000000030000000000000000000000000",
        "000000000000010200000000000030001000000010030000",
        "000000000020030000000000000030000000000000002010000000000000020010000000000000020200000000000000030000000000",
        "003070000300003000060302003000000300020030000307003000030000003020030000003006000300600030020003000030000300",
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
        for (int i = 0; i < introChunks.Count; i++)
        {
            chunkHolder.LoadChunk(introChunks[i]);
        }

        chunksToUnlock.Add(easyChunks);
        chunksToUnlock.Add(mediumChunks);
        chunksToUnlock.Add(hardChunks);
        chunksToUnlock.Add(superHardChunks);
        chunksToUnlock.Add(extremeChunks);
        chunksToUnlock.Add(almostImpossibleChunks);

        StartCoroutine(Unlocking());
    }

    IEnumerator Unlocking()
    {
        //the cooldown before adding
        yield return new WaitForSeconds(unlockSeconds[counter]);

        //the list we are currently adding
        List<string> currentChunkList = chunksToUnlock[counter];

        //add every chunk
        for (int i = 0; i < currentChunkList.Count; i++)
        {
            chunkHolder.LoadChunk(currentChunkList[i]);
        }

        counter++;

        CheckLeftoverChunks();
    }

    void CheckLeftoverChunks()
    {
        //if our counter is above our list with chunks length, we added all chunks that exist and we exit the loop
        if (counter < chunksToUnlock.Count)
            StartCoroutine(Unlocking());
    }

}
