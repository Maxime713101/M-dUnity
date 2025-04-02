using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class PlayerInteraction : MonoBehaviour
{
    public Camera Cam;
    private bool IsTalking = false;
    private bool canInteract = true;

    private string nomobjet = "";
    public Material outlineMaterial;
    public Canvas uiobjetproche;
    private float DistanceInteraction = 3f;
    public GameObject InteractionText;
    private Interactable_obj CurrentInteractable;
    private Renderer currentRenderer;
    private Material[] originalMaterials; // Sauvegarde des matériaux de base

    void Start()
    {
        IsTalking = false;
    }

    // sUpdate is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, DistanceInteraction))
        {
            Interactable_obj interactableObj = hit.collider.GetComponent<Interactable_obj>();

            if (interactableObj != null && interactableObj != CurrentInteractable)
            {
                if (CurrentInteractable != null)
                {
                    RemoveOutline(); // Supprime l'outline de l'ancien objet regardé
                }

                
                CurrentInteractable = interactableObj;
                currentRenderer = CurrentInteractable.GetComponent<Renderer>();

                if (currentRenderer != null)
                {
                    originalMaterials = currentRenderer.materials; // Sauvegarde les matériaux d'origine
                    AddOutline(); // Ajoute l'outline
                }

                InteractionText.SetActive(true);
                TextMeshProUGUI textcomponent = InteractionText.GetComponent<TextMeshProUGUI>();

                if (textcomponent != null)
                {
                    textcomponent.text = CurrentInteractable.GetInteractionText();
                }
            }
        }
        else
        {
            if (CurrentInteractable != null)
            {
                RemoveOutline(); // Supprime l'outline quand on ne regarde plus l'objet
                CurrentInteractable = null;
            }

            
            InteractionText.SetActive(false);
        }

        // Interaction avec l'objet
        if (!IsTalking && canInteract && Input.GetKeyDown(KeyCode.E) && CurrentInteractable != null)
        {
            CurrentInteractable?.Interact();

            if (CurrentInteractable.tag != "Objet")
            {
                Cam.transform.LookAt(CurrentInteractable.transform);
            }
            else if(CurrentInteractable.tag == "Objet")
            {
                GameObject CurrentObjet = CurrentInteractable.gameObject.GetComponent<GameObject>();
                nomobjet = CurrentObjet.name;
                Debug.Log(CurrentObjet.name);
            }
        }
    }

    void AddOutline()
    {
        if (currentRenderer != null && outlineMaterial != null)
        {
            Material[] newMaterials = new Material[originalMaterials.Length + 1];
            for (int i = 0; i < originalMaterials.Length; i++)
            {
                newMaterials[i] = originalMaterials[i];
            }
            newMaterials[originalMaterials.Length] = outlineMaterial;
            currentRenderer.materials = newMaterials;
        }
    }

    void RemoveOutline()
    {
        if (currentRenderer != null && originalMaterials != null)
        {
            currentRenderer.materials = originalMaterials; // Remet les matériaux d'origine
        }
    }

    public void Conversation()
    {
        IsTalking = true;
        canInteract = false;
    }

    public void EndConversation()
    {
        IsTalking = false;
        canInteract = true;
    }
}