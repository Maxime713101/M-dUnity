using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteTrigger : MonoBehaviour
{
    public AudioClip ouvertureClip;
    public AudioClip fermetureClip;

    public AudioSource audioSource;
    public Animator animator;
    private bool porteOuverte = false;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("PlayerDansZone", true);
            porteOuverte = true;
            Debug.Log("jerentre");

            if (porteOuverte == true)
            {
                animator.SetBool("Open",true);
                animator.SetBool("Close", false);
                audioSource.Stop();
                audioSource.clip = ouvertureClip;
                audioSource.Play();
                Debug.Log("audio jouer");
            }
        }
    }
    

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jesort");
            animator.SetBool("PlayerDansZone", false);
            porteOuverte = false;

            if (porteOuverte == false)
            {
                animator.SetBool("Close", true);
                animator.SetBool("Open", false);
                audioSource.Stop();
                audioSource.clip = fermetureClip;
                audioSource.Play();
                
            }
        }
    }
}
