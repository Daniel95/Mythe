using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    private int x;

    private int y;

    private int objNumber;

    private Image image;

    private Sprite sprite;

    private ObjectSelection objectSelection;

    private Color startColor;

    [SerializeField]
    private Color selectedColor;

    void Start() {
        image.sprite = ObjectsInNodeInfo.Sprites[objNumber];
        startColor = image.color;
    }

    void Awake() {
        image = GetComponent<Image>();

        objectSelection = GameObject.Find("ObjectSelectionMenu").GetComponent<ObjectSelection>();
    }

    void OnDisable() {
        objectSelection.DoneSelecting -= SetNewObject;
    }

    public void Init(int _x, int _y, int _objectValue, int _maxObjNumber) {
        x = _x;
        y = _y;
        objNumber = _objectValue;
    }

    public void ChangeObject() {
        //set the color to selectedColor
        image.color = selectedColor;

        objectSelection.DoneSelecting += SetNewObject;


        //objectSelection.StartMenu(x, y);
        objectSelection.StartMenu(GetComponent<Node>());
    }

    public void SetNewObject(int _newObjNumber) {
        //reset the color of the object
        image.color = startColor;

        objNumber = _newObjNumber;
        image.sprite = ObjectsInNodeInfo.Sprites[objNumber];

        //unsubscribe itself to the setnewobject method, because it is done editing
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
