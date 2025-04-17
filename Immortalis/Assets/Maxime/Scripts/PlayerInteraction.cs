using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


[RequireComponent(typeof(Player_controller))]
public class PlayerInteraction : MonoBehaviour
{
    //public variable
    public Camera Cam;
    public Material outlineMaterial;
    public GameObject uiobjetproche;
    public GameObject InteractionText;
    public GameObject uiobjetinventaire;
    public GameObject LookatStart;
    public RapprochementMeduse Meduse;
    public bool InteractionBoss;


    private Animator AnimatorCurrentObject;

    //private variable
    private bool IsTalking = false;
    private bool canInteract = true;
    private Player_controller player_controller;
    private float DistanceInteraction = 3f;   
    private Interactable_obj CurrentInteractable;
    private Renderer currentRenderer;
    private Material[] originalMaterials; // Sauvegarde des matériaux de base
    private int index=0;

    //Rotation des objets
    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    // Limites de rotation des objets
    private float minRotationY = -45f;  // Limite inférieure pour la rotation verticale (axe Y)
    private float maxRotationY = 45f;
    private float minRotationX = -45f;  // Limite inférieure pour la rotation verticale (axe Y)
    private float maxRotationX = 45f;
    bool HasParameter(Animator animator, string paramName, AnimatorControllerParameterType type)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName && param.type == type)
            {
                return true;
            }
        }
        return false;
    }

    void Start()
    {
        IsTalking = false;
        player_controller = GetComponent<Player_controller>();
        Vector3 CustomLookAtStart = new Vector3(LookatStart.transform.position.x, this.transform.position.y, LookatStart.transform.position.z);
        this.transform.LookAt(CustomLookAtStart);
        MouseNotVisible();   
    }

    // sUpdate is called once per frame
    void Update()
    {
        Vector3 CustomLookAtStart = new Vector3(LookatStart.transform.position.x, this.transform.position.y, LookatStart.transform.position.z);
        if (index < 2)
        {
            this.transform.LookAt(CustomLookAtStart);
            index += 1;
        }
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
            AnimatorCurrentObject = CurrentInteractable.GetComponentInChildren<Animator>();

            CurrentInteractable?.Interact();
            RemoveOutline();
            MouseVisible();

            if (AnimatorCurrentObject != null) 
            {
                if (HasParameter(AnimatorCurrentObject, "Talking", AnimatorControllerParameterType.Bool))
                {
                    AnimatorCurrentObject.SetBool("Talking", true);
                }
            }
            

            if (CurrentInteractable.tag == "humain")
            {
                Vector3 CustoomLookAtPNJ = new Vector3(CurrentInteractable.transform.position.x, this.transform.position.y, CurrentInteractable.transform.position.z);
                Cam.transform.LookAt(CustoomLookAtPNJ);
            }

            else if(CurrentInteractable.tag == "Objet" || CurrentInteractable.tag =="ObjetBon")           
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
                        textuiobjet[2].text = "Revenir en arrière";
                    }
                    else 
                    {
                        textuiobjet[2].text = "Prendre l'objet";
                        
                    }
                }
                
        
            }
            else if(CurrentInteractable.tag == "JournalDeplie")
            {
                uiobjetproche.SetActive(true);

                if (uiobjetproche != null)
                {
                    TextMeshProUGUI descriptioncurrentobjet = CurrentInteractable.GetComponentInChildren<TextMeshProUGUI>();
                    TextMeshProUGUI[] textuiobjet = uiobjetproche.GetComponentsInChildren<TextMeshProUGUI>();
                    MeshFilter[] meshcurrentobjet = CurrentInteractable.GetComponentsInChildren<MeshFilter>();
                    MeshFilter meshui = uiobjetproche.GetComponentInChildren<MeshFilter>();
                    MeshRenderer[] currentobjetrenderer = CurrentInteractable.GetComponentsInChildren<MeshRenderer>();
                    MeshRenderer uirenderer = uiobjetproche.GetComponentInChildren<MeshRenderer>();

                    //donner les caracteristique du current objet à l'ui (le nom de l'objet, sa description et son mesh)
                    meshui.mesh = meshcurrentobjet[1].mesh;
                    uirenderer.materials = currentobjetrenderer[1].materials;
                    textuiobjet[0].text = CurrentInteractable.name;
                    textuiobjet[1].text = descriptioncurrentobjet.text;

                    player_controller.BeginConversation();

                    textuiobjet[2].text = "Revenir en arrière";

                }
            }
        }

        //Pouvoir faire tourner l'objet lorsque uiobjetproche est actif
        if (uiobjetproche != null)
        {
            RectTransform[] meshGameObject = uiobjetproche.GetComponentsInChildren<RectTransform>();

            float mouserotationx = Input.GetAxis("Mouse X") * 2.0f;
            float mouserotationy = Input.GetAxis("Mouse Y") * 2.0f;

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
        MouseNotVisible();
    }
    public void DansInventaire()
    {
        Image[] imageobjet = CurrentInteractable.GetComponentsInChildren<Image>();
        Image[] inventaireimage = uiobjetinventaire.GetComponentsInChildren<Image>();
        

        if (imageobjet != null && CurrentInteractable.tag == "ObjetBon")
        {
            inventaireimage[1].sprite = imageobjet[0].sprite;
            uiobjetinventaire.SetActive(true);
        }
        else if (imageobjet != null && CurrentInteractable.tag == "AppareilPhoto")
        {
            if( Meduse.MeduseIsCloser == true)
            {
                inventaireimage[1].sprite = imageobjet[2].sprite;
                uiobjetinventaire.SetActive(true);
                Meduse.PhotoMedusebon();
            }
            else
            {
                //lancer phrase d'echec
            }
        }
    }
    public void MouseVisible()
    {
        UnityEngine.Cursor.visible = true;
        
    }
    public void MouseNotVisible()
    {
        UnityEngine.Cursor.visible = false;
        
    }

    public void PNJStopTalking()
    {

        if (HasParameter(AnimatorCurrentObject, "Talking", AnimatorControllerParameterType.Bool))
        {
            AnimatorCurrentObject.SetBool("Talking", false);
        }
    }

    public void prendreObjet()
    {
        if(CurrentInteractable != null)
        {
            CurrentInteractable.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractionBoss")
        {
            InteractionBoss = true;
        }
    }
}