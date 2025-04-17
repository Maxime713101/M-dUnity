using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MissionManager : MonoBehaviour
{
    public UnityEvent ChangementTask;
    private int nbpatientparler = 0;

    public GameObject TacheDebutSprite;
    public GameObject TacheChimieOnly;
    public GameObject TachePatientOnly;
    public GameObject TacheFinisSprite;
    public GameObject TachePhotoUndoSpr;
    public GameObject TachePhotoDoSpr;
    public GameObject TacheFinalSpr;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TacheDebut()
    {
        TacheDebutSprite.SetActive(true);
    }
    public void OnlyTacheChimieDid()
    {
        
        TacheChimieOnly.SetActive(true);
        TacheDebutSprite.SetActive(false);
    }

    public void OnlyTachePatientDid()
    {
        if(nbpatientparler == 3)
        {
            TachePatientOnly.SetActive(true);
            TacheDebutSprite.SetActive(false);
        }
    }
    public void TacheFinis()
    {
        if(nbpatientparler == 4)
        {
            TacheFinisSprite.SetActive(true);
            TachePatientOnly.SetActive(false);
            TacheChimieOnly.SetActive(false);
            ChangementTask.Invoke();
        }
    }

    public void TachePhotoUndo()
    {
        TachePhotoUndoSpr.SetActive(true);
        TacheFinisSprite.SetActive(false);
    }

    public void TachePhotoDo()
    {
        TachePhotoUndoSpr.SetActive(false);
    }

    public void TacheFinal()
    {
        
        TacheFinalSpr.SetActive(true);
    }
    public void TacheFinalDisparait()
    {
        TacheFinalSpr.SetActive(false);
    }

    public void CompterPatientParler()
    {
        nbpatientparler++;
    }
}
