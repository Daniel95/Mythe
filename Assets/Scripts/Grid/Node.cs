using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    private int x;

    private int y;

    private int objNumber;

    private int maxObjNumber;

    private Image image;

    private Sprite sprite;

    void Start() {
        image = GetComponent<Image>();
        image.sprite = ObjectsInNode.Sprites[objNumber];
    }

    public void Init(int _x, int _y, int _objectValue, int _maxObjNumber) {
        x = _x;
        y = _y;
        objNumber = _objectValue;
        maxObjNumber = _maxObjNumber;
    }

    public void ChangeObject() {
        objNumber++;
        if (objNumber >= maxObjNumber) objNumber = 0;
        image.sprite = ObjectsInNode.Sprites[objNumber];

        transform.parent.GetComponent<ChunkEditor>().EditChunk(x, y, objNumber);
    }

    public void Reset() {
        objNumber = 0;
        image.sprite = ObjectsInNode.Sprites[objNumber];
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
