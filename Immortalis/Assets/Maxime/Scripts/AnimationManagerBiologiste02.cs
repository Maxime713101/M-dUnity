using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerBiologiste02 : MonoBehaviour
{
    public TransitionAnimationDiscussion AnimationManagerMrYork;
    public Animator BiologisteAnimator;
    private float speed = 1.0f;
    private bool goaway = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimationManagerMrYork.IsTalking == true) 
        {
            BiologisteAnimator.SetBool("IsTalking", true);
            Debug.Log("Je parle la");
        }
        if (AnimationManagerMrYork.IsMoving == true) 
        {
            BiologisteAnimator.SetBool("IsMoving",true);
            
            goaway = true;  
            
        }
        if (goaway == true) 
        {
            transform.LookAt(Vector3.left);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
