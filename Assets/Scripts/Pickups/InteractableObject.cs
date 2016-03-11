using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
    /*
    This class is for each object where the play can interact with effecting the waterbar.
    It contains two varriables, the value (can be negative for obstacles and positive for pickups increasing or decreasing the water bar.
    */
    [SerializeField]
    private float healthValue = 0.12f;

    [SerializeField]
    private bool poolOnTouch;

    [SerializeField]
    private string animToPlayName;

    private Animator anim;

    private Collider2D coll;

    void Start() {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    public virtual void Touched() {
        if (anim != null)
        {
            //play the animation
            anim.SetTrigger(animToPlayName);

            //destroy this object after the animation if boolean is true
            if (poolOnTouch)
                StartCoroutine(PoolAfterAnimation());
        }
    }

    public float HealthValue
    {
        get { return healthValue; }
    }

    IEnumerator PoolAfterAnimation()
    {
        //wait for the animation to start
        while (!anim.GetCurrentAnimatorStateInfo(0).IsName(animToPlayName)) {
            yield return new WaitForFixedUpdate();
        }
        
        //when started, wait for it to end
        while(anim.GetCurrentAnimatorStateInfo(0).IsName(animToPlayName))
        {
            yield return new WaitForFixedUpdate();
        }

        ObjectPool.instance.PoolObject(gameObject);
    }
}
