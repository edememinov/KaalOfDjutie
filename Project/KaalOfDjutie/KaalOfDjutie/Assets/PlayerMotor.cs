using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;

    private Vector3 rotation = Vector3.zero;

    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    //Get movement Vector
    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }


    //Get rotation Vector
    public void Rotate(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    //Get rotation Vector for the camera
    public void RotateCamera(Vector3 cameraRotation)
    {
        this.cameraRotation = cameraRotation;
    }

    //Runs every physics iteration
    void FixedUpdate ()
    {
        PreformMovement();
        PerformRotation();
    }

    void PreformMovement ()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }
    }
}
