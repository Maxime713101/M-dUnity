using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    public Camera Cam;
    private bool IsTalking = false;
    float DistanceInteraction = 3f;
    public GameObject InteractionText;
    private Interactable_obj CurrentInteractable; 
    // Start is called before the first frame update
    void Start()
    {
        IsTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, DistanceInteraction))
        {
            Interactable_obj interactableObj = hit.collider.GetComponent<Interactable_obj>();
            if(interactableObj != null && interactableObj != CurrentInteractable)
            {
                CurrentInteractable = interactableObj;
                InteractionText.SetActive(true);       
                TextMeshProUGUI textcomponent = InteractionText.GetComponent<TextMeshProUGUI>();
                if(textcomponent != null)
                {
                    textcomponent.text = CurrentInteractable.GetInteractionText();
                }
            }
        }
        else
        {
            CurrentInteractable = null;
            InteractionText.SetActive(false);
        }
        
        if(IsTalking == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentInteractable?.Interact();
                Cam.transform.LookAt(CurrentInteractable.transform);
            }
        }

    }
    public void Conversation()
    {
        IsTalking = true;
        
    }
    public void EndConversation()
    {
        IsTalking = false;
    }
}
