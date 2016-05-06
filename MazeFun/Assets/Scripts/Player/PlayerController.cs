using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start() {
        motor = GetComponent<PlayerMotor>();
    }



    void Update()
    {
        //Calculate camera rotation as a 3D vector(turning Around)
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Calculate camera rotation as a 3D vector(turning Around)
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(-_xRot, 0f, 0f) * lookSensitivity;
        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);
    }

}
