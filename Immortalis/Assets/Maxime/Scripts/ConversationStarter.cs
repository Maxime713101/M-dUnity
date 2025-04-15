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
            else if (index == 4)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[4]);
            }
            else if (index == 5)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[5]);
            }
            else if (index == 6)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[6]);
            }
            else if (index == 7)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[7]);
            }
            else if (index == 8)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[8]);
            }
            else if (index == 9)
            {
                interactiontext.SetActive(false);
                ConversationManager.Instance.StartConversation(SecretaireConversations[9]);
            }


        }

    }
    public void recupproduitchimique()
    {
        index = 5;
    }
    public void SecretaireDemandeouverturePorteSeul()
    {
        index = 2;
    }
    public void portechimiqueouverte()
    {
        index = 3;
    }
    public void SecretairephraseBateau()
    {
        index = 4;
    }
    public void PhotoPriseOnchercheMrYork()
    {
        index = 6;
    }

}
