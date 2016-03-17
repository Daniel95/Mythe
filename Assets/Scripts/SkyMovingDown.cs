using UnityEngine;
using System.Collections;

public class SkyMovingDown : MonoBehaviour
{
    private float heigth;
    [SerializeField]
    private float fadeSpeed = 0.01f;
    private GameObject secondImage;
    [SerializeField]
    private bool delayAble = false;

    void Start()
    {
        secondImage = transform.FindChild("sky").gameObject;
        heigth = (transform.FindChild("up").transform.position.y - transform.position.y) * 2f;
    }
    public void FormingSky()
    {
        StartCoroutine(SkyForm());
    }
    public void FormingGround()
    {
        StartCoroutine(NormalForm());
    }
    IEnumerator SkyForm()
    {
        if (delayAble)
        {
            yield return new WaitForSeconds(1f);
        }
        Color temp = GetComponent<SpriteRenderer>().color;
        while (temp.a <= 1)
        {
            temp.a += fadeSpeed;
            GetComponent<SpriteRenderer>().color = secondImage.GetComponent<SpriteRenderer>().color = temp;
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator NormalForm()
    {
        if (!delayAble)
        {
            yield return new WaitForSeconds(1f);
        }
        Color temp = GetComponent<SpriteRenderer>().color;
        while (temp.a >= 0)
        {
            temp.a -= fadeSpeed;
            GetComponent<SpriteRenderer>().color = secondImage.GetComponent<SpriteRenderer>().color = temp;
            yield return new WaitForFixedUpdate();
        }
    }
}

