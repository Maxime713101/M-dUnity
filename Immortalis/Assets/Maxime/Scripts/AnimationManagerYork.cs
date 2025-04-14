using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DialogueEditor;
using UnityEngine;

public class TransitionAnimationDiscussion : MonoBehaviour
{
    public Animator animatorYork;
    public GameObject Player;
    public bool IsTalking;
    public bool Islookingplayer;
    private Vector3 CustomLookAt;
    public Transform StopPosition;
    private float speed = 1.0f;
    public bool IsMoving;
    public SkinnedMeshRenderer bodyYork;
    //private bool yorkistalking = true;
    // Start is called before the first frame update
    void Start()
    {
        CustomLookAt = Vector3.zero;
        

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, StopPosition.transform.position);
        

        if (Islookingplayer == true)
        {

            CustomLookAt.Set(Player.transform.position.x, transform.position.y, Player.transform.position.z);

            Debug.DrawRay(transform.position, transform.forward,Color.red);

            transform.LookAt(CustomLookAt);
            
            Debug.DrawRay(transform.position, transform.forward,Color.green);
        }

        if (IsMoving == true) 
        {
            if (dist >= 1.2f) 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                
            }
            else
            {
                IsMoving = false;
                animatorYork.SetBool("Arrived", true);
            }
                     
        }
        //if(yorkistalking == false)
        //{

        //    int index = bodyYork.sharedMesh.GetBlendShapeIndex("V_Lip_Open");
        //    Debug.Log(index);
        //    bodyYork.SetBlendShapeWeight(index, 0f);
        //    bodyYork.SetBlendShapeWeight(0, 0f);
        //    bodyYork.SetBlendShapeWeight(2, 0f);
        //    bodyYork.SetBlendShapeWeight(3, 0f);
            
        //}
        
    }
    IEnumerator Findelaconversation()
    {
        yield return new WaitForSeconds(2);
        animatorYork.SetBool("Transition", true);
        Islookingplayer = true;
        IsMoving = true;
    }
    public void findelaconversation() 
    {
        StartCoroutine(Findelaconversation());
        
    }
    public void fininteraction()
    {
        Islookingplayer = false;
    }
    public void debutconversation()
    {
        animatorYork.SetBool("IsTalking", true);
        IsTalking = true;
    }
    //public void YorkNotTalking()
    //{
    //    yorkistalking = false;
        
    //}
}
