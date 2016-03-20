using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HealthBar : MonoBehaviour
{
    private float health;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private float loseHealthSpeed = 0.03f;
    [SerializeField]
    private Image waterRenderer;

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
    private TrailMovementTest trailMovement;

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
        if (_value > 0)
            trailMovement.SpawnTrail();
    }

    private IEnumerator SuperMode()
    {
        gameSpeed.SuperMode();
        superGenerator.SetActive(true);
        generateOneObject.SpawnObject();
        generateChunk.ShouldSpawn = false;
        cameraZoom.ZoomCameraOut();

        for (int i = 0; i < skiesMovingDown.Length; i++) {
            skiesMovingDown[i].FormingSky();
        }

        audioSource.PlayOneShot(audioClip);
        //while you're in super sayen mode.
        while (health > maxHealth / 2)
        {
            //your bar drops twice as fast.
            currentHealth -= loseHealthSpeed * 2;

            //color is green.
            waterRenderer.color = Color.green;

            yield return new WaitForFixedUpdate();
        }
        generateChunk.PauzeSpawning(2);
        StartCoroutine(NormalMode());
    }

    private IEnumerator NormalMode()
    {
        gameSpeed.NormalMode();
        superGenerator.SetActive(false);

        cameraZoom.ZoomCameraIn();

        for (int i = 0; i < skiesMovingDown.Length; i++)
        {
            skiesMovingDown[i].FormingGround();
        }

        while (health < maxHealth)
        {
            //normal speed.
            currentHealth -= loseHealthSpeed;

            //the color is based of the vaule, when it goes to zero, it becomes more red, when towards maxhealth, it becomes more blue.
            waterRenderer.color = new Color(1 - currentHealth / maxHealth, 0, currentHealth / maxHealth);
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
            else if(currentHealth > maxHealth)
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
        StopCoroutine(UpdateHealthbar());
        health = currentHealth = 0;
        audioSource.PlayOneShot(audioClip);
        Vector3 temp = transform.localScale;
        temp.x = health;
        transform.localScale = temp;

        trailMovement.DestroyTrailParts(0);

        finishGame.Finish();
        playerObject.SetActive(false);
    }

    public void Restart()
    {
        generateChunk.PauzeSpawning(3);
        currentHealth = maxHealth / 2;

        //start the updatehealth after reseting player health, otherwise it will trigger die() & try to get highscores
        StartCoroutine(UpdateHealthbar());

        trailMovement.SpawnStartTrail();

        playerObject.SetActive(true);
        playerObject.GetComponent<PlayerMovement>().StartTrailSpawning();
    }
}

