using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduseFinal : MonoBehaviour
{
    public GameObject MeduseFinals;
    public Transform LookAt;
    public GameObject Player;
    public GameObject ParticuleElectricité;
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AppuyerSurBouton()
    {
        Animator[] MeduseFinalAnimator = MeduseFinals.GetComponentsInChildren<Animator>();
        Player.transform.LookAt(LookAt);
        ParticuleElectricité.SetActive(true);
        lights.SetActive(true);
        for(int i = 0; i<12; i++)
        {
            MeduseFinalAnimator[i].speed = 5.0f;
        }
        
        StartCoroutine(CoupDejus());
    }
    IEnumerator CoupDejus()
    {
        Animator[] MeduseFinalAnimator = MeduseFinals.GetComponentsInChildren<Animator>();

        yield return new WaitForSeconds(1.0f);
        ParticuleElectricité.SetActive(false);
        lights.SetActive(false);
        for (int i = 0; i < 12; i++)
        {
            MeduseFinalAnimator[i].speed = 1.0f;
        }
    }
    public void flashlight()
    {

    }
}
