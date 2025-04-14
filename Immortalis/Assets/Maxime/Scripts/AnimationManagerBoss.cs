using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationManagerBoss : MonoBehaviour
{
    public PlayerInteraction PlayerInteraction;
    public Transform PlayerPosition;
    public Animator AnimatorPorteR;
    public Animator AnimatorPorteL;
    public Camera cameraplayer;
    private bool PlayermovFor = true;
    private bool PlayermovLeft = false;
    private Vector3 CustomLookAt; 
    public UnityEvent OnPlayerEnter;
    public Transform PositionBossStop;
    public Transform BossLeavePosition;
    public Animator BossAnimator;
    // Start is called before the first frame update
    void Start()
    {
        PlayermovLeft = false;
        CustomLookAt = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, PositionBossStop.position);

        if (PlayerInteraction.InteractionBoss == true) 
        {   
            //Ouverture des portes, arrêt du player et regard du player sur le boss

            AnimatorPorteR.SetBool("PlayerEnter",true);
            AnimatorPorteL.SetBool("PlayerEnter", true);
            cameraplayer.transform.LookAt(this.transform);
            
            OnPlayerEnter.Invoke();

            //Le boss marche jusqu'a atteindre un certain point
            if (dist >= 1.2f)
            {
                this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
                CustomLookAt.Set(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z);
                transform.LookAt(CustomLookAt);
            }
            else
            {
                BossAnimator.SetBool("IsTalking", true);
            }
            

            if(PlayermovFor == true)
            {
                PlayerPosition.Translate(Vector3.forward * 2.0f * Time.deltaTime);
                StartCoroutine(PlayerMovFor());
            }
            else if (PlayermovLeft == true) 
            {
                PlayerPosition.Translate(Vector3.left * 1.0f * Time.deltaTime);
                StartCoroutine(PlayerMovLeft());
            }
            
            
            
        }
    }
    private IEnumerator PlayerMovFor()
    {
        yield return new WaitForSeconds(1);
        PlayermovFor = false;
        PlayermovLeft = true;
        
    }
    private IEnumerator PlayerMovLeft()
    {
        yield return new WaitForSeconds(1);
        PlayermovLeft= false;
    }

    }
