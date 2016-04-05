using UnityEngine;
using System.Collections;

public class TutorialUnlocker : MonoBehaviour {

    [SerializeField]
    private ChunkHolder chunkHolder;
    [SerializeField]
    private GenerateChunk generateChunk;
    [SerializeField]
    private PlayerDistance playerDistance;
    void Awake()
    {
        
    }
    void Start () {
        StartCoroutine(ForceIntroChunks());
	}
	IEnumerator ForceIntroChunks()
    {
        //intro game with two rows of obstacles and some water.
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("100001100001110301100001100001100001100001100001103011100001100001100001"));

        //intro chunk for super modus.
        while (playerDistance.Distance < 10)
        {
            yield return new WaitForFixedUpdate();
        }
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("111111111111111111111111111121111111111111121111111121111111111111113311113311133331133331333333333333333333000000"));

        //intro chunk for shield pick up.
        while (playerDistance.Distance < 20)
        {
            yield return new WaitForFixedUpdate();
        }
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("000000000000111111111111000000000500000000010010100001"));


        //intro chunk for magnet pick up up.
        while (playerDistance.Distance < 30)
        {
            yield return new WaitForFixedUpdate();
        }
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("000000000000110000310000110011000013000011000000000000004000000000000000"));


        //intro chunk for side walk enemies.
        while (playerDistance.Distance < 40)
        {
            yield return new WaitForFixedUpdate();
        }
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("000000000300000000000000000007000000000000000300000000000000700000000000000000"));


        //intro chunk for iaming enemies.
        while (playerDistance.Distance < 50)
        {
            yield return new WaitForFixedUpdate();
        }
        generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("000000000000000000000000000030000000060003000000000030000000000000000000000000"));


    }
}
