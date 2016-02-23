using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float health;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private Image waterRenderer;
    private bool superSayenMode = false;

    [SerializeField]
    private FinishGame finishGame;

    private bool playing = true;

	void Start () {
        //maxhealth is a scale value and currenthealth and speed are based from maxhealth.
        //this makes it possible to scale the bar without editing the script.
        maxHealth = transform.localScale.x;
        currentHealth = maxHealth/2;
        health = currentHealth;
        speed = maxHealth / 1000;
	}

	public void addValue(float _value){
        //adds value to currenthealth.
        currentHealth += _value;
        
    }

    void FixedUpdate()
    {
        if (playing)
        {
            if (health > maxHealth)
            {
                superSayenMode = true;
                currentHealth = maxHealth;
            }

            //when in supersayenform,
            if (superSayenMode)
            {
                //your bar drops twice as fast.
                currentHealth -= speed * 2;

                //color is green.
                waterRenderer.color = Color.green;

                //goes over when you reach the half of your bar.
                if (currentHealth < maxHealth / 2)
                {
                    superSayenMode = false;
                }
            }

            //when you are in normal mode.
            else
            {
                //normal speed.
                currentHealth -= speed;

                //the color is based of the vaule, when it goes to zero, it becomes more red, when towards maxhealth, it becomes more blue.
                waterRenderer.color = new Color(1 - currentHealth / maxHealth, 0, currentHealth / maxHealth);
            }

            //this makes sure that when you add value, it will go towards to it, instead of transporting to the new value.
            if (health > currentHealth)
            {
                health = currentHealth;
            }
            else
            {
                health += speed * 8;
            }

            //when your bar is zero.
            if (currentHealth <= 0)
            {
                Die();
            }

            //updates the scale of the water value giving visual feedback.
            Vector3 temp = transform.localScale;
            temp.x = health;
            transform.localScale = temp;
        }
	}

    private void Die() {
        playing = false;
        health = 0;
        finishGame.Finish();
    }

    public void Restart() {
        playing = true;

        currentHealth = maxHealth / 2;
    }
}
