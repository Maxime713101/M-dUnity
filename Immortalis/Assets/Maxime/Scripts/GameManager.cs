
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject MenuPause;
    public UnityEvent StopControl;
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
            StopControl.Invoke();
        }  
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
