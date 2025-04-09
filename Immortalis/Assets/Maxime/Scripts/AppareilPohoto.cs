using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppareilPohoto : MonoBehaviour
{
    public GameObject flashappareil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flash()
    {
        flashappareil.SetActive(true);
        StartCoroutine(flashspeed());
    }
    IEnumerator flashspeed()
    {
        
        yield return new WaitForSeconds(0.1f);
        flashappareil.SetActive(false);
    }
}
