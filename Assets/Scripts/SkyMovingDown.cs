using UnityEngine;
using System.Collections;

public class SkyMovingDown : MonoBehaviour
{
    //private float heigth;
    [SerializeField]
    private float fadeSpeed = 0.01f;
    private GameObject secondImage;
    [SerializeField]
    private bool delayAble = false;
    [SerializeField]
    private float maxAlpha = 1;


    void Start()
    {
        secondImage = transform.FindChild("sky").gameObject;
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
        while (temp.a <= maxAlpha)
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

