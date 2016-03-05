using UnityEngine;

public class ChunkEditor : MonoBehaviour {

    [SerializeField]
    private GenerateChunk generateChunk;

    [SerializeField]
    private ChunkHolder chunkLibary;

    [SerializeField]
    private Transform buildPosition;

    [SerializeField]
    private GameObject editableNodePrefab;

    private int lastYLength = 0;

    private int[,] editableChunk;

    public void EditChunkHeight() {
        //instantiate editableChunk again with a new y length
        editableChunk = new int[ChunkHolder.xLength, ChunkHolder.CurrentYLength];

        //if last Y Length is lower then the current Y Length, add nodes to the chunk
        if (lastYLength < ChunkHolder.CurrentYLength)
        {
            AddNodesToChunk();
        } //else remove nodes from chunk
        else {
            RemoveNodesFromChunk();
        }

        lastYLength = ChunkHolder.CurrentYLength;

        chunkLibary.CompresChunk(editableChunk);
    }

    public void AddNodesToChunk() {
        int currentYLength = transform.childCount / ChunkHolder.xLength;

        for (int y = currentYLength; y < ChunkHolder.CurrentYLength; y++)
        {
            for (int x = 0; x < ChunkHolder.xLength; x++)
            {
                //spawn the editableChunk, positive x values are to the right, and negative y values are down. so this creates a grid from top left, to down right, just like the [,]. 
                GameObject editableNode = (GameObject)Instantiate(editableNodePrefab, new Vector3(x * 33, -y * 33, 0) + buildPosition.position, transform.rotation) as GameObject;

                //give the node his starting position and values
                editableNode.GetComponent<Node>().Init(x, y, 0, generateChunk.objToSpawnNameLength());

                //we are the parent of this node
                editableNode.transform.SetParent(transform);
            }
        }
    }

    public void RemoveNodesFromChunk()
    {
        //destroy every chunk that does no longer exist in the editableChunk
        foreach (Node _node in transform.GetComponentsInChildren<Node>())
        {
            //the node y starts at 0, so if the node y is bigger or the same as Ylength, destroy it
            if (_node.Y >= ChunkHolder.CurrentYLength)
            {
                Destroy(_node.gameObject);
            }
        }
    }

    public void EditChunk(int _xPos, int _yPos, int _value)
    {
        editableChunk[_xPos, _yPos] = _value;
        chunkLibary.CompresChunk(editableChunk);
    }

    public void SaveChunk()
    {
        chunkLibary.AddChunk(editableChunk);

        ResetChunk();
    }


    public void ResetChunk() {
        editableChunk = new int[ChunkHolder.xLength, ChunkHolder.CurrentYLength];
        
        foreach (Node _node in transform.GetComponentsInChildren<Node>())
        {
            _node.Reset();
        }
    }
}
