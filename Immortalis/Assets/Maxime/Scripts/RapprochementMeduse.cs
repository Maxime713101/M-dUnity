using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class RapprochementMeduse : MonoBehaviour
{
    public GameObject Meduse;
    public GameObject PositionFinalMeduse;
    private float speed = 0.5f;
    private bool MeduseMoving;
    public bool MeduseIsCloser;
    public GameObject Player;

    public UnityEvent PhotoMeduseBon;
    public UnityEvent MeduseAssezProche;
    public UnityEvent PlayerParleMeduse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionFinalMeduse = PositionFinalMeduse.transform.position.x;
        float dist = Vector3.Distance(Meduse.transform.position, PositionFinalMeduse.transform.position);
        Vector3 CustomLookAt = new Vector3(Player.transform.position.x,Meduse.transform.position.y, Player.transform.position.z);

    
        if (MeduseMoving == true && dist>0.8f)
        {
            Meduse.transform.LookAt(CustomLookAt);
            Meduse.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }     

    }
   
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.tag == "Player")
        {
            MeduseMoving = true;
            PlayerParleMeduse.Invoke();
        }
        if (other.tag == "Meduse")
        {
            MeduseIsCloser = true;
            MeduseAssezProche.Invoke();
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
