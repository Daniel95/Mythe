using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade: MonoBehaviour {
    private float fadeSpeed = 0.01f;
    [SerializeField] private SpriteRenderer fadeImage;
    private Color temp;
    [SerializeField]
    private float maxAlpha = 1;

    public void StartFade()
    {
        StartCoroutine(FadeIn());
    }
    public void EndFade()
    {
        StartCoroutine(FadeOver());
    }
    IEnumerator FadeIn()
    {
        while (fadeImage.color.a < maxAlpha)
        {
            temp = fadeImage.color;
            temp.a += fadeSpeed;
            fadeImage.color = temp;
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator FadeOver()
    {
        while (fadeImage.color.a > 0)
        {
            temp = fadeImage.color;
            temp.a -= fadeSpeed;
            fadeImage.color = temp;
            yield return new WaitForFixedUpdate();
        }
    }
}
