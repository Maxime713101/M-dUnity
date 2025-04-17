
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject MenuPause;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            MenuPause.SetActive(true);
            UnityEngine.Cursor.visible = true;
            Time.timeScale = 0;
            
        }  
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void BackToGame()
    {
        Time.timeScale = 1;
    }
}
