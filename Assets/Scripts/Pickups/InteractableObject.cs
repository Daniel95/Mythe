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

    [SerializeField]
    private float animScale = 1;

    private float startScale;

    [SerializeField]
	private bool playAnimOnDeath = true;

	private Animator anim;

	private Collider2D coll;

	void Start() {
		anim = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
        startScale = transform.localScale.x;
	}

	public virtual void Touched() 
	{
		if (playAnimOnDeath) 
		{
			//play the animation
			anim.SetTrigger (animToPlayName);

			//destroy this object after the animation if boolean is true
			if (poolOnTouch) 
			{
				StartCoroutine (PoolAfterAnimation ());
			}
		} 
		else if (poolOnTouch)
			ObjectPool.instance.PoolObject(gameObject);
	}

	public float HealthValue
	{
		get { return healthValue; }
	}

	IEnumerator PoolAfterAnimation()
	{
		//coll.enabled = false;
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

        transform.localScale = new Vector2(startScale, startScale);

        ObjectPool.instance.PoolObject(gameObject);
    }
}