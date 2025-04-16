using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button targetButton;          // Le bouton UI à écouter
    public AudioSource audioSource;      // L'audio source à utiliser pour jouer le son

    private void Start()
    {
        if (targetButton != null && audioSource != null)
        {
            targetButton.onClick.AddListener(PlayClickSound);
        }
        else
        {
            Debug.LogWarning("ButtonSound: Assign both the Button and AudioSource in the inspector.");
        }
    }

    public void PlayClickSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); 
        }
    }
}
