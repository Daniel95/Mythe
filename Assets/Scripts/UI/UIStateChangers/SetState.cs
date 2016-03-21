using UnityEngine;

public class SetState : MonoBehaviour
{

    [SerializeField]
    private bool startState;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(startState);
    }

    //change the active state of a object.
    public void ChangeState()
    {
        gameObject.SetActive(!startState);
        startState = !startState;
    }
}
