using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_movement : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    private Vector3 Velocity;
    private Vector3 Rotation;
    private Vector3 Camerarotation;
    private Rigidbody rgb;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        Velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        Rotation = _rotation;
    }
    public void cameraRotate(Vector3 _camerarotation)
    {
        Camerarotation = _camerarotation;
    }
    public void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    private void PerformMovement()
    {
        if (Velocity != Vector3.zero)
        {
            rgb.MovePosition(rgb.position + Velocity * Time.fixedDeltaTime);
        }
    }
    private void PerformRotation()
    {
        rgb.MoveRotation(rgb.rotation * Quaternion.Euler(Rotation));
        cam.transform.Rotate(- Camerarotation);
    }

}
