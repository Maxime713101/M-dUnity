using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    public GameObject UiChargement;
    public TextMeshProUGUI TextChargement;
public void startgame()
    {
        StartCoroutine(chargementscene());
    }
public void quitgame()
    {
        Application.Quit();
    }
IEnumerator chargementscene()
    {
        AsyncOperation result = SceneManager.LoadSceneAsync("LaurieScene");

        while (!result.isDone)
        {
            UiChargement.SetActive(true);
            float progress = Mathf.Clamp01(result.progress / 0.9f);
            TextChargement.text = "Chargement " + (progress * 100) + "%";
            
            yield return null;
        }
    }
}
