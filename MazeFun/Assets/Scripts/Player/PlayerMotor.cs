using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Vector3 cameraRotation = Vector3.zero;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    //Gets Move Vector
    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }

    //Gets Rotate Vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets Rotate Vector for the camera
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void FixedUpdate() { 
        PerformRotate();
        PerformMovemet();
    }

    void PerformMovemet() {
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotate() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null) {
            cam.transform.Rotate(cameraRotation);
        }
    }


}
