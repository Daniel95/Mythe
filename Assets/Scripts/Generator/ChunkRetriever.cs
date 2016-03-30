﻿using UnityEngine;

public class ChunkRetriever : MonoBehaviour {

    [SerializeField]
    private ChunkHolder chunkHolder;

    [SerializeField]
    private ChunkUnlocker chunkUnlocker;

    void Start() {
        //daniel new chunks
        chunkHolder.LoadChunk("100000000100030001000000");
        chunkHolder.LoadChunk("000000000300000010020000000000");

        //nathan new chunks
        //too hard on mobile for beginners, add later again, when chunkunlocker works
        //chunkHolder.LoadChunk("000300000000600000000006600000000006600000003006000000000000");
        chunkHolder.LoadChunk("000000011100100003100000000110000001005000000000");
        chunkHolder.LoadChunk("000000111103000000");
        chunkHolder.LoadChunk("000000301111000000");
        chunkHolder.LoadChunk("000000000000000000131030131000000000000000000000000000030131000131000000000000000000");
        chunkHolder.LoadChunk("000000000020000000003000000300020000000000");
        chunkHolder.LoadChunk("000000000000030000000100000000000000010001000000100010000000010001000300100000000000000010000000");
        chunkHolder.LoadChunk("000000000000001000010000100301000010000100001030001030000100003010100010010010010010010010100001");
        chunkHolder.LoadChunk("010000000000030000000103000100100000000000");
        chunkHolder.LoadChunk("000000003000200000000000111100000000");
        chunkHolder.LoadChunk("110011000000000000");
        chunkHolder.LoadChunk("000000000300000010020000000000");
        chunkHolder.LoadChunk("000000000300000010020000000000");
        chunkHolder.LoadChunk("000000000300000010020000000000");
        chunkHolder.LoadChunk("000000000300000010020000000000");

        //daniel old chunks
        chunkHolder.LoadChunk("000000000000030000000030000000");
        chunkHolder.LoadChunk("0000000100000000010000300000000");
        chunkHolder.LoadChunk("000000000000001100000000000000");
        chunkHolder.LoadChunk("000000000030001000000010000000");
        chunkHolder.LoadChunk("010001000010100000010000000001");
        chunkHolder.LoadChunk("000100000030001000000300000010001100000001");
        chunkHolder.LoadChunk("000000000100000000");
        chunkHolder.LoadChunk("010030000000030000000300000000000000003000000003000000000030");
        chunkHolder.LoadChunk("000000030000000000000000000100001000100000000000000001000000");
        chunkHolder.LoadChunk("000000000030010000000000");
        chunkHolder.LoadChunk("000000000301000030000300000000");
        chunkHolder.LoadChunk("000000010000000010010000000000");
        chunkHolder.LoadChunk("000100000001000000000300001000000000000010");
        chunkHolder.LoadChunk("010010100001000000000400");
        chunkHolder.LoadChunk("010010100001000000000400");
        chunkHolder.LoadChunk("000000143351000000000000000000001100000000");
        chunkHolder.LoadChunk("000100000000004003000100101000000000003010");
        chunkHolder.LoadChunk("000000031000000000000000000130000000000000031000");
        chunkHolder.LoadChunk("000000041150000000");
        chunkHolder.LoadChunk("000000000000000300000000010000000000000030000000030000000000");
        chunkHolder.LoadChunk("000000000000000000010010000000113311000000010010000000000000");
        chunkHolder.LoadChunk("000000000000000000000010000030013000000030000010000000000000");
        chunkHolder.LoadChunk("000000000000030000000000010001000300000000");
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