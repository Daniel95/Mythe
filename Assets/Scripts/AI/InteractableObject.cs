using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
    /*
    This class is for each object where the play can interact with effecting the waterbar.
    It contains two varriables, the value (can be negative for obstacles and positive for pickups increasing or decreasing the water bar.
    */
    [SerializeField]
    private float value;
    [SerializeField]
    private bool destroyOnTouch;
    public float Value
    {
        get { return value; }
    }
    public bool DestroyOnTouch
    {
        get { return destroyOnTouch; }
    }
}
