using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EcranFinFadeOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    void Start()
    {
        
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
    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());  
    }
}
