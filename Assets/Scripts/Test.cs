using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    [SerializeField]
    private GenerateChunk generateChunk;

    [SerializeField]
    private ChunkHolder chunkHolder;

    int cooldown = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cooldown--;
        if (cooldown < 0)
        {
            cooldown = 1000;
            generateChunk.MakeChosenChunk(chunkHolder.UncompressChunk("111111111111130001000000"));
        }
    }
}
