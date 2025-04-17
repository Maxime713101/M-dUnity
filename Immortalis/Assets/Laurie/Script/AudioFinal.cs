using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AudioFinal : MonoBehaviour
{
    public GameObject SourceAmbiance;
    public GameObject AllAmbiance;
    public UnityEvent LouisonRemarque;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LouisonRemarque.Invoke();
            SourceAmbiance.SetActive(true);
            AllAmbiance.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SourceAmbiance.SetActive(false);

        }
    }
}
