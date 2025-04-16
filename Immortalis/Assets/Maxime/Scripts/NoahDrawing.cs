using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject BoutonRecuperObjet;

    public GameObject DescriptionObjet;

    public GameObject DessinNoahPasFinit;
    public GameObject DessinNoahFinit;

    public GameObject Crayon;

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
                    DessinNoahFinit.SetActive(true);
                    DessinNoahPasFinit.SetActive(false);
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
        BoutonRecuperObjet.SetActive(false);

        if(uiobjetproche != null)
        {
            TextMeshProUGUI[] textuiobjet = uiobjetproche.GetComponentsInChildren<TextMeshProUGUI>();
            MeshFilter meshui = uiobjetproche.GetComponentInChildren<MeshFilter>();
            MeshRenderer uirenderer = uiobjetproche.GetComponentInChildren<MeshRenderer>();

            textuiobjet[0].text = "Dessin de Noah";
            textuiobjet[1].text = "";
            meshui.mesh = DessinMesh.mesh;
            uirenderer.materials = DessinTexture.materials;
        }

    }
    public void FinitConversationNoah()
    {
        BoutonRecuperObjet.SetActive(true);
        uiobjetproche.SetActive(false);
    }
}
