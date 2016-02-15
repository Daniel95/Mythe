using UnityEngine;
using System.Collections;

public class WaterBar : MonoBehaviour {

    private float health;
    private float currentHealth;
    private float maxHealth;
    private float speed = 0.01f;
    private SpriteRenderer waterRenderer;
    private bool superSayenMode = false;
   
	void Start () {

        //gets the renderer of the image of the child with the name: value.
        waterRenderer = transform.FindChild("value").GetComponent<SpriteRenderer>();

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

    void Update() {


        //this input with space can be deleted, its only for test purposes.
        //-----
        if (Input.GetKeyDown("space"))
        {
            addValue(0.1f);
        }
        //-----



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

            //the color is based of the vaule, when it goes to zero, it becomes more red, wjen towards maxhealth, it becomes more blue.
            waterRenderer.color = new Color(1 - currentHealth / maxHealth, 0, currentHealth / maxHealth);            
        }
        
        //this makes sure that when you add value, it will go towards to it, instead of transporting to the new value.
        if(health > currentHealth)
        {
            health = currentHealth;
        }
        else
        {
            health += speed * 4;
        }

        //when your bar is zero.
        if (currentHealth <= 0)
        {
            Debug.Log("you're dead!");
            Destroy(this.gameObject);
        }

        //updates the scale of the water value giving visual feedback.
        Vector3 temp = transform.localScale;
        temp.x = health;
        transform.localScale = temp;
	}
}
