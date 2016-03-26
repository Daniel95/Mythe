using UnityEngine;

public class ChunkEditor : MonoBehaviour
{

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

    void Awake()
    {
        editableChunk = new int[ChunkHolder.xLength, ChunkHolder.CurrentYLength];
    }

    public void EditChunkHeight()
    {
        int[,] temporaryGrid = editableChunk;

        //instantiate editableChunk again with a new y length
        editableChunk = new int[ChunkHolder.xLength, ChunkHolder.CurrentYLength];

        CopyValuesIn2dArray(temporaryGrid);

        //if last Y Length is lower then the current Y Length, add nodes to the chunk
        if (lastYLength < ChunkHolder.CurrentYLength)
        {
            AddNodesToChunk();
        } //else remove nodes from chunk
        else
        {
            RemoveNodesFromChunk();
        }

        lastYLength = ChunkHolder.CurrentYLength;

        chunkLibary.CompressChunk(editableChunk);
    }

    public void AddNodesToChunk()
    {
        //the y length is the total length of the all the chunks, divided by its X length
        int currentYLength = transform.childCount / ChunkHolder.xLength;

        //loop through every node in the chunk
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

    //copies the values of the grid onto
    public void CopyValuesIn2dArray(int[,] _temporaryGrid)
    {
        //loop through every node in the chunk
        for (int y = 0; y < _temporaryGrid.Length / ChunkHolder.xLength; y++)
        {
            for (int x = 0; x < ChunkHolder.xLength; x++)
            {
                if (editableChunk.Length / ChunkHolder.xLength > y)
                {
                    editableChunk[x, y] = _temporaryGrid[x, y];
                }
            }
        }
    }

    public void EditChunk(int _xPos, int _yPos, int _value)
    {
        editableChunk[_xPos, _yPos] = _value;
        chunkLibary.CompressChunk(editableChunk);
    }

    public void SaveChunk()
    {
        chunkLibary.AddChunk(editableChunk);

        ResetChunk();
    }


    public void ResetChunk()
    {
        editableChunk = new int[ChunkHolder.xLength, ChunkHolder.CurrentYLength];

        foreach (Node _node in transform.GetComponentsInChildren<Node>())
        {
            _node.Reset();
        }
    }
}