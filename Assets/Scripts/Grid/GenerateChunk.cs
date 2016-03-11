using UnityEngine;
using System.Collections;

public class GenerateChunk : MonoBehaviour {

    [SerializeField]
    private float divideGridHeightWaitTime = 3.8f;

    [SerializeField]
    private ChunkHolder chunkLibary;

    [SerializeField]
    private string[] objectToSpawnNames;

    [SerializeField]
    private GameObject spawnPos;

    private bool alreadySpawning;

    public void StartSpawning() {
        if (!alreadySpawning)
        {
            MakeChunk();
            alreadySpawning = true;
        }
    }

    public void MakeChunk()
    {
        //get a random chunk
        int[,] chunkToSpawn = chunkLibary.GetRandomChunk();

        //calculate the y Length of this chunk, take its total length and divide it by its width.
        int yLength = chunkToSpawn.Length / ChunkHolder.xLength;

        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < ChunkHolder.xLength; x++)
            {
                if (objectToSpawnNames[chunkToSpawn[x, y]] != "")
                {
                    //put the number of the grid into the objectToSpawnName array to check the right name for that object, then send it to object pool
                    GameObject spawnedObject = ObjectPool.instance.GetObjectForType(objectToSpawnNames[chunkToSpawn[x, y]], true);

                    spawnedObject.transform.position = new Vector2(x, -y + yLength) + (Vector2)spawnPos.transform.position;
                }
            }
        }

        //start counting down again before spawning a new one
        StartCoroutine(WaitBeforeNextSpawn(yLength));
    }

    IEnumerator WaitBeforeNextSpawn(int _ylenth)
    {
        //this is the time we are waiting before we spawn another chunk
        //take the ylength
        //then divide it by divideGridHeightWaitTime to make the wait time adjustable
        //then divide it by the gamet time speed in this game + 1, so the time becomes shorter the longer the game plays on
        float timeToWait = _ylenth / divideGridHeightWaitTime / GameSpeed.SpeedMultiplier;

        yield return new WaitForSeconds(timeToWait);

        //Since the IENumerator and function call on each other objects will spawn in intervals.
        MakeChunk();
    }

    public int objToSpawnNameLength()
    {
        return objectToSpawnNames.Length;
    }
}
