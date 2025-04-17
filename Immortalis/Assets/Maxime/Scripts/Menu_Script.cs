using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
public void startgame()
    {
        SceneManager.LoadScene("LaurieScene");
    }
public void quitgame()
    {
        Application.Quit();
    }
}
