using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cinemachine;
public class EcranOrdinateur : MonoBehaviour
{
   
    public GameObject cameraOrdi;
    public TMP_InputField codetext;
    public GameObject PanelEnterCode;
    public GameObject TextCodeFaux;
    public GameObject ImageLaboFermer;
    public GameObject ImageLaboOuvert;
    public GameObject EcranPorteOuverte;
    public GameObject EcranPorteFermer;
    private Vector3 CameraPoisition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchCamOrdi()
    {
        cameraOrdi.SetActive(true);
    }
    public void switchCamPlayer()
    {
        cameraOrdi.SetActive(false);
    }
    public void checkCode()
    {
        if(codetext.text == "0123")
        {
            
            PanelEnterCode.SetActive(false);
            ImageLaboFermer.SetActive(false);
            ImageLaboOuvert.SetActive(true);
            EcranPorteOuverte.SetActive(true) ;
            EcranPorteFermer.SetActive(false);
        }
        else
        {
            TextCodeFaux.SetActive(true);
        }
    }
}
