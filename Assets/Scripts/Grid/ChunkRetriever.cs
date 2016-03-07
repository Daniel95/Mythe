using UnityEngine;

public class ChunkRetriever : MonoBehaviour {

    [SerializeField]
    private ChunkHolder chunkHolder;

    [SerializeField]
    private GenerateChunk generateChunk;

    void Start() {
        chunkHolder.LoadChunk("000000000000020000000020000000");
        chunkHolder.LoadChunk("0000000100000000010000200000000");
        chunkHolder.LoadChunk("000000000000001100000000000000");
        chunkHolder.LoadChunk("000000000020001000000010000000");
        chunkHolder.LoadChunk("010001000010100000010000000001");
        chunkHolder.LoadChunk("000100000020001000000200000010001100000001");
        chunkHolder.LoadChunk("000000000100000000");
        chunkHolder.LoadChunk("010020000000020000000200000000000000002000000002000000000020");
        chunkHolder.LoadChunk("000000020000000000000000000100001000100000000000000001000000");
        chunkHolder.LoadChunk("000000000020010000000000");
        chunkHolder.LoadChunk("000000000201000020000200000000");
        chunkHolder.LoadChunk("000000010000000010010000000000");
        chunkHolder.LoadChunk("000100000001000000000200001000000000000010");
        //generateChunk.StartSpawning();
    }
}
