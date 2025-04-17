using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbiance : MonoBehaviour
{

    public GameObject SourceAmbiance;

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
            SourceAmbiance.SetActive(true);

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
