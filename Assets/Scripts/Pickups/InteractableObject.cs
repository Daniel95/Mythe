using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
	/*
    This class is for each object where the play can interact with effecting the waterbar.
    It contains two varriables, the value (can be negative for obstacles and positive for pickups increasing or decreasing the water bar.
    */
	[SerializeField]
	private float healthValue = 0.1f;

	[SerializeField]
	private bool poolOnTouch;

	[SerializeField]
	private string animToPlayName;

    [SerializeField]
    private float animScale = 1;

    private Vector2 startScale;

    [SerializeField]
	private bool playAnimOnDeath = true;

    private Collider2D myCollider;

    private Animator anim;

    private bool isEnabled = true;

	private MoveDown moveDown;

    void Awake()
    {
        anim = GetComponent<Animator>();

        myCollider = GetComponent<Collider2D>();

        startScale = transform.localScale;

		moveDown = GetComponent<MoveDown> ();
    }

    void OnEnable() {
        //enable the collision
        isEnabled = true;

        myCollider.enabled = true;

        //reset itself to its starting scale, in case it was scaled up or down during an animation
        transform.localScale = startScale;
		moveDown.Move = true;
        if(healthValue > 0.05)
        {
            healthValue -= GameSpeed.SpeedMultiplier / 10f;
        }
    }

	public virtual void Touched() 
	{
		if (isEnabled) {
            if (playAnimOnDeath)
            {
                //play the animation
                anim.SetTrigger(animToPlayName);

                //destroy this object after the animation if boolean is true
                if (poolOnTouch)
                {
                    StartCoroutine(PoolAfterAnimation());
                }
            }
            else if (poolOnTouch)
                ObjectPool.instance.PoolObject(gameObject);
		}
	}

	public float HealthValue
	{
		get { return healthValue; }
	}

	IEnumerator PoolAfterAnimation()
	{
        //disable the collision
        isEnabled = false;

        //wait for the animation to start
        while (!anim.GetCurrentAnimatorStateInfo(0).IsName(animToPlayName)) {
			yield return new WaitForFixedUpdate();
		}

        transform.localScale = new Vector2(animScale, animScale);

		//when started, wait for it to end
		while(anim.GetCurrentAnimatorStateInfo(0).IsName(animToPlayName))
		{
			yield return new WaitForFixedUpdate();
		}

        ObjectPool.instance.PoolObject(gameObject);
    }

    public bool IsEnabled {
        set { isEnabled = value; }
        get { return isEnabled; }
    }
}