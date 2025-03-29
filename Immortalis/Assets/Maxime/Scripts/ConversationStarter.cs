using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation[] SecretaireConversation;
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
        if (index == 0)
        {
            interactiontext.SetActive(false);
            ConversationManager.Instance.StartConversation(SecretaireConversation[0]);
            index += 1;
            
        }
        else if (index == 1)
        {
            ConversationManager.Instance.StartConversation(SecretaireConversation[1]);
                
        }

    }
}
