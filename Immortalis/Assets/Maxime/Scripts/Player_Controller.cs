using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Player_movement))]

public class Player_controller : MonoBehaviour
{
    public float Speed = 3.0f;
    public float mouse_sensitivx = 1.0f;
    public float mouse_sensitivy = 5.0f;
    private Player_movement PlayerMov;
    private bool IsTalking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        IsTalking = false;
        PlayerMov = GetComponent<Player_movement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsTalking == false)
        {
            float XMov = Input.GetAxisRaw("Horizontal");
            float ZMov = Input.GetAxisRaw("Vertical");

            Vector3 MovementHorizontal = transform.right * XMov;
            Vector3 MovementVertical = transform.forward * ZMov;

            Vector3 Velocity = (MovementHorizontal + MovementVertical).normalized * Speed;

            PlayerMov.Move(Velocity);

            float yrot = Input.GetAxisRaw("Mouse X");
            Vector3 rotation = new Vector3(0, yrot, 0) * mouse_sensitivy;


            PlayerMov.Rotate(rotation);

            float xrot = Input.GetAxisRaw("Mouse Y");
            Vector3 camerarotation = new Vector3(xrot, 0, 0) * mouse_sensitivx;

            PlayerMov.cameraRotate(camerarotation);
        }

    }
    public void BeginConversation()
    {
        IsTalking = true;
        PlayerMov.canLook = false; // bloque la rotation
        PlayerMov.StopVelocity();  // arrête le mouvement

    }
    public void EndConversation()
    {
        IsTalking = false;
        PlayerMov.canLook = true;
    }
}
