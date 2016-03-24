using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    private int x;

    private int y;

    private int objNumber;

    private int maxObjNumber;

    private Image image;

    private Sprite sprite;

    private ObjectSelection objectSelection;

    void Start() {
        image.sprite = ObjectsInNodeInfo.Sprites[objNumber];
    }

    void Awake() {
        image = GetComponent<Image>();

        objectSelection = GameObject.Find("ObjectSelectionMenu").GetComponent<ObjectSelection>();
    }

    void OnEnable() {
       // objectSelection.DoneSelecting += SetNewObject;
    }

    void OnDisable() {
        //objectSelection.DoneSelecting -= SetNewObject;
    }

    public void Init(int _x, int _y, int _objectValue, int _maxObjNumber) {
        x = _x;
        y = _y;
        objNumber = _objectValue;
        maxObjNumber = _maxObjNumber;
    }

    public void ChangeObject() {
        objectSelection.DoneSelecting += SetNewObject;
        objectSelection.StartMenu(x, y);
        
            /*
        objNumber++;
        if (objNumber >= maxObjNumber) objNumber = 0;
        image.sprite = ObjectsInNode.Sprites[objNumber];

        GameObject.FindObjectOfType<ChunkEditor>();

        transform.parent.GetComponent<ChunkEditor>().EditChunk(x, y, objNumber);
        */
    }

    public void SetNewObject(int _newObjNumber) {
        objNumber = _newObjNumber;
        image.sprite = ObjectsInNodeInfo.Sprites[objNumber];
        objectSelection.DoneSelecting -= SetNewObject;
    }

    public void Reset() {
        objNumber = 0;
        image.sprite = ObjectsInNodeInfo.Sprites[objNumber];
    }

    public int X {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public int ObjNumber
    {
        get { return objNumber; }
    }
}
