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
    private SpriteRenderer[] shadows;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip gameOverAudioClip;

    [SerializeField]
    private AudioClip superModeAudioClip;

    [SerializeField]
    private float supermodeSoundFadeSpeed = 0.01f;

    private bool superModeIsOn;

    private float startVolume;

    [SerializeField]
    private ParticleSystem groundParticles;

    void Start()
    {
        //maxhealth is a scale value and currenthealth and speed are based from maxhealth.
        //this makes it possible to scale the bar without editing the script.
        maxHealth = transform.localScale.x;
        currentHealth =  maxHealth / 2;
        health = currentHealth;

        //begins with the coroutine normal mode.
        StartCoroutine(NormalMode());

        //declares the generator for supermode.
        generateOneObject = superGenerator.GetComponent<GenerateOneObject>();

        //begins updating the update healthbar.
        StartCoroutine(UpdateHealthbar());

        //begins with generating chunks.
        generateChunk.MakeRandomChunk();

        startVolume = audioSource.volume;
    }

    public void addValue(float _value)
    {
        //adds value to currenthealth.
        currentHealth += _value;
    }

    private IEnumerator SuperMode()
    {
        if (EnterSuperMode != null)
            EnterSuperMode();

        audioSource.clip = superModeAudioClip;
        audioSource.Play();

        superModeIsOn = true;

        //get every hurtable obstacle
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(Tags.obstacle);
        foreach(GameObject obstacle in obstacles)
        {
            //deactivates the colliders of the object making it for the player safer to og in supermode.
            if(obstacle.GetComponent<BoxCollider2D>() != null) obstacle.GetComponent<BoxCollider2D>().enabled = false;
            else if(obstacle.GetComponent<CircleCollider2D>() != null) obstacle.GetComponent<CircleCollider2D>().enabled = false;
        }
        //deactivates the ground particles.
        groundParticles.enableEmission = false;

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

        //stops the supermode music with a fade
        StartCoroutine(SoundFade());

        gameSpeed.NormalMode();
        superGenerator.SetActive(false);
        cameraZoom.ZoomCameraIn();
        circleObject.GetComponent<RainbowEffect>().enabled = false;
        circleObject.GetComponent<Image>().color = new Color(0, 255, 255, 255);
        for (int i = 0; i < skiesMovingDown.Length; i++)
        {
            skiesMovingDown[i].FormingGround();
        }
        groundParticles.enableEmission = true;

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
            for (int i = 0; i < shadows.Length; i++)
            {
                shadows[i].color = new Color(0, 0, 0, health / 4 - 0.06f);
            }
            yield return new WaitForFixedUpdate();
        }
        Die();
    }

    public void Die()
    {
        if(PlayerDied != null)
            PlayerDied();

        groundParticles.enableEmission = false;
        StopCoroutine(UpdateHealthbar());
        health = currentHealth = 0;
        audioSource.PlayOneShot(gameOverAudioClip);
        Vector3 temp = transform.localScale;
        temp.x = health;
        transform.localScale = temp;

        finishGame.Finish();
        playerObject.SetActive(false);
    }

    private IEnumerator SoundFade()
    {
        while (audioSource.volume > 0) {
            audioSource.volume -= supermodeSoundFadeSpeed;
            yield return new WaitForFixedUpdate();
        }
        audioSource.Stop();
        audioSource.volume = startVolume;

        superModeIsOn = false;
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }

    public bool SuperModeIsOn {
        get { return superModeIsOn; }
    }
}

