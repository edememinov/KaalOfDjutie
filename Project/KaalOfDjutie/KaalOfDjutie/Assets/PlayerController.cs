using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;
    
    

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMovement; 

        Vector3 movVertical = transform.forward * zMovement;

        //Final movement vector
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        //Apply movement
        motor.Move(velocity);

        //Calculate rotatation as a 3D Vector (Truning around)
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Apply Rotation
        motor.Rotate(rotation);


        //Calculate camera rotation as a 3D Vector (Truning around)
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(-xRot, 0f, 0f) * lookSensitivity;

        //Apply Camera rotation
        motor.RotateCamera(cameraRotation);

        

    }
}
