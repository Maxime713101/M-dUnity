using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahDrawing : MonoBehaviour
{
    public Animator NoahAnimator;
    public ConversationStarter NoahConversation;
    private bool SecretaireIsGone;
    public GameObject PerfusionNoahIdle;
    public GameObject PerfusionNoahDrawing;
    public MeshFilter DessinMesh;
    public MeshRenderer DessinTexture;
    public GameObject uiobjetproche;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(NoahConversation.index == 1)
            {
                NoahConversation.index = 2;
                NoahAnimator.SetBool("IsDrawing", true);
                PerfusionNoahDrawing.SetActive(true);
                PerfusionNoahIdle.SetActive(false);
            }
            if(NoahConversation.index == 2)
            {
                if (SecretaireIsGone == true)
                {
                    NoahConversation.index = 3;
                    NoahAnimator.SetBool("IsDrawing", false);
                    PerfusionNoahDrawing.SetActive(false);
                    PerfusionNoahIdle.SetActive(true);
                }

            }
        }
    }
    public void NoahFinitDessin()
    {
        SecretaireIsGone = true;
    }
    public void RegarderDessinNoah()
    {
        uiobjetproche.SetActive(true);

        if(uiobjetproche != null)
        {
            MeshFilter meshui = uiobjetproche.GetComponentInChildren<MeshFilter>();
            MeshRenderer uirenderer = uiobjetproche.GetComponentInChildren<MeshRenderer>();

            meshui.mesh = DessinMesh.mesh;
            uirenderer.materials = DessinTexture.materials;
        }

    }
}
