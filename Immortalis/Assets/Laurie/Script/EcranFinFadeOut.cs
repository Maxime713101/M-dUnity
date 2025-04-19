using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EcranFinFadeOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float fadeDurationBegin = 2f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed <= fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Pour être sûr que ce soit à fond
        color.a = 1f;
        fadeImage.color = color;
        SceneManager.LoadScene("GeneriqueFin");
    }
    public IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        color.a = 1f; // Commence opaque
        fadeImage.color = color;

        while (elapsed <= fadeDurationBegin)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - (elapsed / fadeDurationBegin));
            fadeImage.color = color;
            yield return null;
        }

        // Pour être sûr que ce soit transparent à la fin
        color.a = 0f;
        fadeImage.color = color;
    }
    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());  
    }
}
