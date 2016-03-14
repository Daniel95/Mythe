using UnityEngine;
using System.Collections;

public class SkyMovingDown : MonoBehaviour {
    
    [SerializeField]
    private bool superForm = false;
    [SerializeField]
    private float fadeSpeed = 0.01f;
    
    [SerializeField]
    private bool delayAble = false;
    private GameObject secondImage;
    void Start () {
        secondImage = transform.FindChild("sky").gameObject;
        StartCoroutine(NormalForm());
    }
    IEnumerator SkyForm()
    {
        while (superForm)
        {
            Color temp = GetComponent<SpriteRenderer>().color;
            if (temp.a < 1)
            {
                temp.a += fadeSpeed;
                GetComponent<SpriteRenderer>().color = secondImage.GetComponent<SpriteRenderer>().color = temp;
            }
            yield return new WaitForFixedUpdate();
        }
        if(!delayAble)
        {
            yield return new WaitForSeconds(1f);
        }
        
        StartCoroutine(NormalForm());
    }
    IEnumerator NormalForm()
    {
        while (!superForm)
        {
            Color temp = GetComponent<SpriteRenderer>().color;
            if (temp.a > 0)
            {
                temp.a -= fadeSpeed;
                GetComponent<SpriteRenderer>().color = secondImage.GetComponent<SpriteRenderer>().color = temp;
            }
            yield return new WaitForFixedUpdate();
        }
        if (delayAble)
        {
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(SkyForm());
    }

    void FixedUpdate () {
        superForm = GameObject.Find("Canvas/Healthbar/Bar").GetComponent<HealthBar>().SuperForm;
        
	}
}
