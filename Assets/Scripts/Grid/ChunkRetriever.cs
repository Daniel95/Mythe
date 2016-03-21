﻿using UnityEngine;

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

        //te lastig
        //chunkHolder.LoadChunk("000000000000001020000000000010010000000010000100100010010000100001001001101000010200010001100010020100000100100010");

        //chunkHolder.LoadChunk("000000002100000000000600000000000000001200000000000000");
        //chunkHolder.LoadChunk("000000000000005000000000000200000000");
        chunkHolder.LoadChunk("000000000000000000111001000000020000000000111100000000000000000111000000000000110020000000000000");
        //chunkHolder.LoadChunk("000000000100000050001000000010000000002000110000000000");
        //chunkHolder.LoadChunk("060020001000000000000010010000001201000000010000000010");
        chunkHolder.LoadChunk("000000001000000020000100000010000000");

        //chunkHolder.LoadChunk("000000060000000000000210000000010000000020");
        chunkHolder.LoadChunk("000000000000000000020100000000021000020000000100101000100000000020000000");
        //chunkHolder.LoadChunk("000000000020010000000000000000000600000100000000000000050000002000000000");
        chunkHolder.LoadChunk("000000020020010010000000");
        chunkHolder.LoadChunk("000000020000000100001000000020020000000000");
        //chunkHolder.LoadChunk("000000000200000050060000002000020000000000");



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