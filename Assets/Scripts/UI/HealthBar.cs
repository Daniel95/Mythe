using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HealthBar : MonoBehaviour
{
    //delegate type
    public delegate void HealthStateMethods();

    //delegate instance
    public HealthStateMethods EnterSuperMode;

    //delegate instance
    public HealthStateMethods EnterNormalMode;

    //delegate instance
    public HealthStateMethods PlayerDied;

    private float health;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private float loseHealthSpeed = 0.0012f;
    [SerializeField]
    private Image waterRenderer;
    [SerializeField]
    private GameObject circleObject;
    [SerializeField]
    private GameObject generator;
    [SerializeField]
    private GameSpeed gameSpeed;

    [SerializeField]
    private GameObject superGenerator;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GenerateChunk generateChunk;

    private GenerateOneObject generateOneObject;

    [SerializeField]
    private FinishGameController finishGame;

    [SerializeField]
    private CameraZoom cameraZoom;

    [SerializeField]
    private SkyMovingDown[] skiesMovingDown;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    private bool restarted;

    void Start()
    {
        //maxhealth is a scale value and currenthealth and speed are based from maxhealth.
        //this makes it possible to scale the bar without editing the script.
        maxHealth = transform.localScale.x;
        currentHealth = maxHealth / 2;
        health = currentHealth;
        StartCoroutine(NormalMode());

        generateOneObject = superGenerator.GetComponent<GenerateOneObject>();

        StartCoroutine(UpdateHealthbar());
        generateChunk.MakeChunk();
    }

    public void addValue(float _value)
    {
        //adds value to currenthealth.
        currentHealth += _value;
    }

    private IEnumerator SuperMode()
    {
        if(EnterSuperMode != null)
            EnterSuperMode();

        
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(Tags.obstacle);
        foreach(GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<BoxCollider2D>().enabled = false;
        }
        circleObject.GetComponent<RainbowEffect>().enabled = true;
        superGenerator.SetActive(true);
        generateOneObject.SpawnObject();
        generateChunk.ShouldSpawn = false;
        waterRenderer.color = Color.green;
        cameraZoom.ZoomCameraOut();
        gameSpeed.SuperMode();
        for (int i = 0; i < skiesMovingDown.Length; i++)
        {
            skiesMovingDown[i].FormingSky();
        }

        audioSource.PlayOneShot(audioClip);
        //while you're in super sayen mode.
        while (health > maxHealth / 2)
        {
            //your bar drops twice as fast.
            currentHealth -= loseHealthSpeed * 2;

            //color is green.


            yield return new WaitForFixedUpdate();
        }
        generateChunk.PauzeSpawning(2);
        StartCoroutine(NormalMode());
    }

    private IEnumerator NormalMode()
    {
        if (EnterNormalMode != null)
            EnterNormalMode();

        gameSpeed.NormalMode();
        superGenerator.SetActive(false);
        cameraZoom.ZoomCameraIn();
        circleObject.GetComponent<RainbowEffect>().enabled = false;
        circleObject.GetComponent<Image>().color = new Color(0, 255, 255, 255);
        for (int i = 0; i < skiesMovingDown.Length; i++)
        {
            skiesMovingDown[i].FormingGround();
        }

        while (currentHealth < maxHealth)
        {
            //normal speed.
            currentHealth -= loseHealthSpeed;

            //the color is based of the vaule, when it goes to zero, it becomes more red, when towards maxhealth, it becomes more blue.
            if(currentHealth < 0.5)
            {
                waterRenderer.color = new Color(1 - currentHealth / maxHealth *2, 0, currentHealth / maxHealth *2);
            }
            else
            {
                waterRenderer.color = new Color(0, 0, 1);
            }
            
            yield return new WaitForFixedUpdate();
        }
        while(health < maxHealth/2)
        {
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(SuperMode());
    }

    private IEnumerator UpdateHealthbar()
    {
        while (currentHealth > 0)
        {
            //this makes sure that when you add value, it will go towards to it, instead of transporting to the new value.
            if (health > currentHealth)
                health = currentHealth;
            else if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            else
                health += loseHealthSpeed * 8;

            //updates the scale of the water value giving visual feedback.
            Vector3 temp = transform.localScale;
            temp.x = health;
            transform.localScale = temp;

            yield return new WaitForFixedUpdate();
        }
        Die();
    }

    public void Die()
    {
        if(PlayerDied != null) PlayerDied();

        StopCoroutine(UpdateHealthbar());
        health = currentHealth = 0;
        audioSource.PlayOneShot(audioClip);
        Vector3 temp = transform.localScale;
        temp.x = health;
        transform.localScale = temp;

        finishGame.Finish();
        playerObject.SetActive(false);
    }

    /*
    public void Restart()
    {
        generateChunk.PauzeSpawning(3);
        currentHealth = maxHealth / 2;

        //start the updatehealth after reseting player health, otherwise it will trigger die() & try to get highscores
        StartCoroutine(UpdateHealthbar());

        trailMovement.StartTrail();

        playerObject.SetActive(true);
        playerObject.transform.position = new Vector2(0, 0);
    }*/

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }
}

