using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationDiscussion : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    private bool Islookingplayer;
    private Vector3 CustomLookAt;
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
    }
    IEnumerator Findelaconversation()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Transition", true);
        Islookingplayer = true;
    }
    public void findelaconversation() 
    {
        StartCoroutine(Findelaconversation());
    }
}
