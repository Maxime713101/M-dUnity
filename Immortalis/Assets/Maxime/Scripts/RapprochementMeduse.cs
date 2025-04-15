using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class RapprochementMeduse : MonoBehaviour
{
    public GameObject Meduse;
    public GameObject PositionFinalMeduse;
    private float speed = 1f;
    private bool MeduseMoving;
    public bool MeduseIsCloser;

    public UnityEvent PhotoMeduseBon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionFinalMeduse = PositionFinalMeduse.transform.position.x;

        if (MeduseMoving == true && positionFinalMeduse < Meduse.transform.position.x)
        {
            Meduse.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }     

    }
   
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.tag == "Player")
        {
            MeduseMoving = true;
        }
        if (other.tag == "Meduse")
        {
            MeduseIsCloser = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MeduseMoving = false;
    }
    public void PhotoMedusebon()
    {
        PhotoMeduseBon.Invoke();
    }
}
