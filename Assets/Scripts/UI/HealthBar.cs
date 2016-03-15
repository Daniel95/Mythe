using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HealthBar : MonoBehaviour
{

    private float health;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private Image waterRenderer;
    private bool superSayenMode = false;
    [SerializeField]
    private GameObject generator;
    [SerializeField]
    private GameObject superGenerator;

    [SerializeField]
    private FinishGameController finishGame;

    private bool playing = true;

    void Start()
    {
        //maxhealth is a scale value and currenthealth and speed are based from maxhealth.
        //this makes it possible to scale the bar without editing the script.
        maxHealth = transform.localScale.x;
        currentHealth = maxHealth / 2;
        health = currentHealth;
        speed = maxHealth / 1000;
        StartCoroutine(NormalMode());
    }

    public void addValue(float _value)
    {
        //adds value to currenthealth.
        currentHealth += _value;

    }

    private IEnumerator SuperSayenMode()
    {
        generator.GetComponent<GameSpeed>().SuperMode();
        superGenerator.SetActive(true);
        superGenerator.GetComponent<GenerateOneObject>().SpawnObject();
        superSayenMode = true;
        //while you're in super sayen mode.
        while (health > maxHealth / 2)
        {
            //your bar drops twice as fast.
            currentHealth -= speed * 2;

            //color is green.
            waterRenderer.color = Color.green;

            yield return new WaitForFixedUpdate();
        }
        superSayenMode = false;
        StartCoroutine(NormalMode());
    }
    private IEnumerator NormalMode()
    {
        generator.GetComponent<GameSpeed>().NormalMode();
        generator.GetComponent<GenerateChunk>().MakeChunk();
        superGenerator.SetActive(false);
        while (health < maxHealth)
        {
            //normal speed.
            currentHealth -= speed;

            //the color is based of the vaule, when it goes to zero, it becomes more red, when towards maxhealth, it becomes more blue.
            waterRenderer.color = new Color(1 - currentHealth / maxHealth, 0, currentHealth / maxHealth);
            yield return new WaitForFixedUpdate();
        }
        superSayenMode = true;
        StartCoroutine(SuperSayenMode());
    }

    void FixedUpdate()
    {
        if (playing)
        {
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
            else if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            //updates the scale of the water value giving visual feedback.
            Vector3 temp = transform.localScale;
            temp.x = health;
            transform.localScale = temp;
        }
    }

    public void Die()
    {
        playing = false;
        health = currentHealth = 0;

        Vector3 temp = transform.localScale;
        temp.x = health;
        transform.localScale = temp;

        finishGame.Finish();
    }

    public void Restart()
    {
        playing = true;

        currentHealth = maxHealth / 2;
    }
    public bool SuperForm
    {
        get { return superSayenMode; }
        set { value = superSayenMode; }
    }
}

