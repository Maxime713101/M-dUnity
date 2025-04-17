using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorteManager : MonoBehaviour
{
    public GameObject OuverturePorteLaboPhoto;
    public GameObject OuverturePorteLaboChimie;
    public GameObject OuverturePorteLaboFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OuvrirLaboPhoto()
    {
        OuverturePorteLaboPhoto.SetActive(true);
    }
    public void OuvrirLaboChimie()
    {
        OuverturePorteLaboChimie.SetActive(true);
    }
    public void OuvrirLaboFinal()
    {
        OuverturePorteLaboFinal.SetActive(true);
    }
}
