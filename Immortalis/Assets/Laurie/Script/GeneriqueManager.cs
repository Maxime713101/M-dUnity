using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneriqueManager : MonoBehaviour
{
    public GameObject[] Ecrans;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangementEcran());
        StartCoroutine(ChangementEcran2());
    }

    // Update is called once per frame
    void Update()
    {
        if(i <= Ecrans.Length + 1)
        {
            Ecrans[i].SetActive(true);
        }
        
    }

    public IEnumerator ChangementEcran()
    {

        yield return new WaitForSeconds(8);
        Ecrans[i].SetActive(false);
        i++;
    }
    public IEnumerator ChangementEcran2()
    {

        yield return new WaitForSeconds(16);
        Ecrans[i].SetActive(false);
        i++;
    }
}
