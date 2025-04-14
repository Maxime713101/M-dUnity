using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerBiologiste02 : MonoBehaviour
{
    public TransitionAnimationDiscussion AnimationManagerMrYork;
    public Animator BiologisteAnimator;
    private float speed = 1.0f;
    private bool goaway = false;
    public Transform DisparitionPoint;
    private Vector3 CustomLookAt;
    // Start is called before the first frame update
    void Start()
    {
        CustomLookAt = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (AnimationManagerMrYork.IsTalking == true) 
        {
            BiologisteAnimator.SetBool("IsTalking", true);
            
        }
        if (AnimationManagerMrYork.IsMoving == true) 
        {
            BiologisteAnimator.SetBool("IsMoving",true);
            
            goaway = true;  
            
        }
        if (goaway == true) 
        {
            transform.LookAt(DisparitionPoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("coucou");
    }
}
