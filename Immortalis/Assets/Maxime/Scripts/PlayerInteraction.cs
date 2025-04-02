using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEditor;

[RequireComponent(typeof(Player_controller))]
public class PlayerInteraction : MonoBehaviour
{
    public Camera Cam;
    private bool IsTalking = false;
    private bool canInteract = true;
    private Player_controller player_controller;
    public Material outlineMaterial;
    public GameObject uiobjetproche;
    private float DistanceInteraction = 3f;
    public GameObject InteractionText;
    private Interactable_obj CurrentInteractable;
    private Renderer currentRenderer;
    private Material[] originalMaterials; // Sauvegarde des matériaux de base
    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    // Limites de rotation
    public float minRotationY = -45f;  // Limite inférieure pour la rotation verticale (axe Y)
    public float maxRotationY = 45f;
    public float minRotationX = -45f;  // Limite inférieure pour la rotation verticale (axe Y)
    public float maxRotationX = 45f;


    void Start()
    {
        IsTalking = false;
        player_controller = GetComponent<Player_controller>();
        
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
            RemoveOutline();

            if (CurrentInteractable.tag != "Objet" && CurrentInteractable.tag != "ObjetBon")
            {
                Cam.transform.LookAt(CurrentInteractable.transform);
            }
            else            
            {
                uiobjetproche.SetActive(true);

                if(uiobjetproche != null)
                {
                    TextMeshProUGUI descriptioncurrentobjet = CurrentInteractable.GetComponentInChildren<TextMeshProUGUI>();
                    TextMeshProUGUI[] textuiobjet = uiobjetproche.GetComponentsInChildren<TextMeshProUGUI>();
                    MeshFilter meshcurrentobjet = CurrentInteractable.GetComponent<MeshFilter>();
                    MeshFilter meshui = uiobjetproche.GetComponentInChildren<MeshFilter>();
                    MeshRenderer currentobjetrenderer = CurrentInteractable.GetComponent<MeshRenderer>();
                    MeshRenderer uirenderer = uiobjetproche.GetComponentInChildren<MeshRenderer>();

                    //donner les caracteristique du current objet à l'ui (le nom de l'objet, sa description et son mesh)
                    meshui.mesh = meshcurrentobjet.mesh;
                    uirenderer.materials = currentobjetrenderer.materials;
                    textuiobjet[0].text = CurrentInteractable.name;
                    textuiobjet[1].text = descriptioncurrentobjet.text;

                    player_controller.BeginConversation();
                    

                    if (CurrentInteractable.tag == "Objet")
                    {
                        textuiobjet[2].text = "Revnir en arrière";
                    }
                    else 
                    {
                        textuiobjet[2].text = "Prendre l'objet";
                        CurrentInteractable.gameObject.SetActive(false);
                    }
                }
        
            }
        }
        //Pouvoir faire tourner l'objet lorsque uiobjetproche est actif
        if (uiobjetproche != null)
        {
            RectTransform[] meshGameObject = uiobjetproche.GetComponentsInChildren<RectTransform>();

            float mouserotationx = Input.GetAxis("Mouse X") * 2.0f;
            float mouserotationy = Input.GetAxis("Mouse Y") * 2.0f;

            Debug.Log(Input.GetAxis("Mouse X"));

            currentRotationX += mouserotationy;
            currentRotationY -= mouserotationx;

            currentRotationY = Mathf.Clamp(currentRotationY, minRotationY, maxRotationY);
            currentRotationX = Mathf.Clamp(currentRotationX,minRotationX, maxRotationX);

            
            meshGameObject[5].transform.localRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
            
            
        }
    }



    void AddOutline()
    {
        if (currentRenderer != null && outlineMaterial != null && CurrentInteractable.tag != "humain")
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
        if (currentRenderer != null && originalMaterials != null && CurrentInteractable.tag != "humain")
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