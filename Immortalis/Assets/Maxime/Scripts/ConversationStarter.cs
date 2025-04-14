using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation[] SecretaireConversations;
    private int index = 0;
    public GameObject interactiontext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartConverstation()
    {
        if(SecretaireConversations != null)
        {
            if (index == 0)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[0]);
                if (SecretaireConversations.Length > 1) 
                {
                    index += 1;
                }
                

            }

            else if (index == 1)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[1]);

            }
            else if (index == 2)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[2]);
            }
            else if (index == 3)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[3]);
            }

        }

    }
    public void recupproduitchimique()
    {
        index = 3;
    }
    public void portechimiqueouverte()
    {
        index = 2;
    }
}
