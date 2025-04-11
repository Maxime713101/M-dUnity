using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TransitionAnimationDiscussion : MonoBehaviour
{
    public Animator animatorYork;
    public GameObject Player;
    private bool IsTalking;
    private bool Islookingplayer;
    private Vector3 CustomLookAt;
    public GameObject StopPosition;
    private float speed = 1.0f;
    private bool IsMoving;
    // Start is called before the first frame update
    void Start()
    {
        CustomLookAt = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Islookingplayer == true)
        {

            CustomLookAt.Set(Player.transform.position.x, transform.position.y, Player.transform.position.z);

            Debug.DrawRay(transform.position, transform.forward,Color.red);

            transform.LookAt(CustomLookAt);
            
            Debug.DrawRay(transform.position, transform.forward,Color.green);
        }

        if (IsMoving == true) 
        { 
            if (transform.position.z >= StopPosition.transform.position.z)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                //Mettre l'animation de parlote (faire une transition dans l'animator)
            }
            
        }

        
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
    public void debutconversation()
    {
        animatorYork.SetBool("IsTalking", true);
    }
}
