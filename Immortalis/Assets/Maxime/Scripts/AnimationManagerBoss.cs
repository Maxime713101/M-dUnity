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

    public GameObject Player;
    private bool PlayermovFor = true;
    private bool PlayermovLeft = false;
    private Vector3 CustomLookAt; 
    private Vector3 CustomLookAtPlayer;
    private bool IsLeaving = false;
    public Transform PositionBossStop;
    public Transform BossLeavePosition;

    public Animator BossAnimator;

    private int index;
    private int indexBeginConv;

    public GameObject EnterBox;

    public UnityEvent OnPlayerEnter;
    public UnityEvent BossDiscution;
    public UnityEvent EndInteraction;


    // Start is called before the first frame update
    void Start()
    {
        PlayermovLeft = false;
        CustomLookAt = Vector3.zero;
        CustomLookAtPlayer = Vector3.zero;
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
            CustomLookAtPlayer.Set(this.transform.position.x,Player.transform.position.y,this.transform.position.z);
            Player.transform.LookAt(CustomLookAtPlayer);

            if (indexBeginConv == 0) 
            {
                OnPlayerEnter.Invoke();
                indexBeginConv += 1;
            }
            

            //Le boss marche jusqu'a atteindre un certain point
            if (dist >= 1.2f)
            {
                this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
                CustomLookAt.Set(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z);
                transform.LookAt(CustomLookAt);
            }
            else
            {
                if(index == 0)
                {
                    BossAnimator.SetBool("IsTalking", true);
                    BossDiscution.Invoke();
                    index += 1;
                }
                
            }


            if (PlayermovFor == true)
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


        if (IsLeaving == true)
        {
            CustomLookAt.Set(BossLeavePosition.position.x, transform.position.y, BossLeavePosition.position.z);
            transform.LookAt(CustomLookAt);
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
        }

    }
    private IEnumerator PlayerMovFor()
    {
        yield return new WaitForSeconds(1.4f);
        PlayermovFor = false;
        PlayermovLeft = true;
        
    }
    private IEnumerator PlayerMovLeft()
    {
        yield return new WaitForSeconds(1);
        PlayermovLeft= false;
    }
    private IEnumerator BossLeavingCoroutine()
    {
        yield return new WaitForSeconds(3);
        PlayerInteraction.InteractionBoss = false;
        AnimatorPorteL.SetBool("DoorClose",true);
        AnimatorPorteR.SetBool("DoorClose", true);
        EndInteraction.Invoke();
    }
    public void BossLeaving()
    {
        BossAnimator.SetBool("IsLeaving", true);
        IsLeaving = true;
        Destroy(EnterBox);  
        StartCoroutine(BossLeavingCoroutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "BossLeavePosition")
        {
            Debug.Log("Cool");
        }
    }

}
