using UnityEngine;

public class ChunkRetriever : MonoBehaviour {

    [SerializeField]
    private ChunkHolder chunkHolder;

    [SerializeField]
    private ChunkUnlocker chunkUnlocker;

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
        chunkHolder.LoadChunk("010010100001000000000300");
        chunkHolder.LoadChunk("010010100001000000000300");
        chunkHolder.LoadChunk("000000132241000000000000000000001100000000");
        chunkHolder.LoadChunk("000100000000003002000100101000000000002010");
        chunkHolder.LoadChunk("000000021000000000000000000120000000000000021000");
        chunkHolder.LoadChunk("000000031140000000");
        chunkHolder.LoadChunk("000000000000000200000000010000000000000020000000020000000000");
        chunkHolder.LoadChunk("000000000000000000010010000000112211000000010010000000000000");
        chunkHolder.LoadChunk("000000000000000000000010000020012000000020000010000000000000");
        chunkHolder.LoadChunk("000000000000020000000000010001000200000000");
        chunkHolder.LoadChunk("000000000100000000");


        /*
        chunkUnlocker.notUnlockedChunks.Add("000000000000020000000020000000");
        chunkUnlocker.notUnlockedChunks.Add("0000000100000000010000200000000");
        chunkUnlocker.notUnlockedChunks.Add("000000000000001100000000000000");
        chunkUnlocker.notUnlockedChunks.Add("000000000020001000000010000000");
        chunkUnlocker.notUnlockedChunks.Add("010001000010100000010000000001");
        chunkUnlocker.notUnlockedChunks.Add("000100000020001000000200000010001100000001");
        chunkUnlocker.notUnlockedChunks.Add("000000000100000000");
        chunkUnlocker.notUnlockedChunks.Add("010020000000020000000200000000000000002000000002000000000020");
        chunkUnlocker.notUnlockedChunks.Add("000000020000000000000000000100001000100000000000000001000000");
        chunkUnlocker.notUnlockedChunks.Add("000000000020010000000000");
        chunkUnlocker.notUnlockedChunks.Add("000000000201000020000200000000");
        chunkUnlocker.notUnlockedChunks.Add("000000010000000010010000000000");
        chunkUnlocker.notUnlockedChunks.Add("000100000001000000000200001000000000000010");
        chunkUnlocker.notUnlockedChunks.Add("010010100001000000000300");
        chunkUnlocker.notUnlockedChunks.Add("010010100001000000000300");
        chunkUnlocker.notUnlockedChunks.Add("000000132241000000000000000000001100000000");
        chunkUnlocker.notUnlockedChunks.Add("000100000000003002000100101000000000002010");
        chunkUnlocker.notUnlockedChunks.Add("000000021000000000000000000120000000000000021000");
        chunkUnlocker.notUnlockedChunks.Add("000000031140000000");
        */
    }
}
