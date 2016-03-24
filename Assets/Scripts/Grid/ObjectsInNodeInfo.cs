using UnityEngine;
using System.Collections.Generic;

public class ObjectsInNodeInfo : MonoBehaviour {

    [SerializeField]
    private List<Sprite> assignSprites;

    private static List<Sprite> sprites;

    public static List<Sprite> Sprites {
        get { return sprites; }
    }

    void Awake()
    {
        sprites = assignSprites;
    }
}
