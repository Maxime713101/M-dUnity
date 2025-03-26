using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_obj : MonoBehaviour
{
    public string interactionText = "Press E to interact";
    public UnityEvent OnInteract; 

    public string GetInteractionText()
    {
        return interactionText;
    }
    public void Interact()
    {
        OnInteract.Invoke();
    }
}
