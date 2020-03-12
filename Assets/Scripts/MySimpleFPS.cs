using UnityEngine;
 
public class MySimpleFPS : MonoBehaviour {
 
    public Rigidbody rb;
    [Range(0,10)] public float rotationSpeed = 3f;
    [Range(0,100)] public float moveSpeed = 15f;
    public Camera cam;

    // Shoot & Raycast
    private float adjustSpeed = 1f;
    public Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 targetNormal;
    private RaycastHit hit;
    public float weight = 9f;
    private LayerMask groundMask;

    // Mouse Look
    public float mouseSensitivity = 200.0f;
     public float clampAngle = 80.0f;
     private float rotationY = 0.0f;
     private float rotationX = 0.0f;
  
    // Start
    void Start() {
        groundMask = LayerMask.GetMask("Ground");
    }

    // Physics updates
    void FixedUpdate () 
    {
        // Lock mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Move Forward, Backward (W, S)
        if (Input.GetKey(KeyCode.W)) {
           transform.position += transform.forward * Time.deltaTime * moveSpeed;
        } else if (Input.GetKey(KeyCode.S)) {
            transform.position += -1 * transform.forward * Time.deltaTime * moveSpeed;
        } 
        
        // Strafe Left/Right
        if (Input.GetKey(KeyCode.A)) {
           transform.position += -1 * transform.right * Time.deltaTime * moveSpeed;
        } else if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }

        // Mouse Look if player is not inputting key
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        rotationX += mouseY * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        rb.MoveRotation(localRotation);

        // Turn Left, Right (A, D) 
        // NOTE: I am disabling turn left / right because it does not make sense to me that the mouse AND A & D controls cameras, as FPS games usually make A and D strafe left/right

        // if (Input.GetKey(KeyCode.A)) {
        //     rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, -1f * rotationSpeed, 0)));
        // } else if (Input.GetKey(KeyCode.D)) {
        //     rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, 1f * rotationSpeed, 0)));
        // } else {
        //     // Mouse Look if player is not inputting key
        //     float mouseX = Input.GetAxis("Mouse X");
        //     float mouseY = -Input.GetAxis("Mouse Y");

        //     rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        //     rotationX += mouseY * mouseSensitivity * Time.deltaTime;

        //     rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        //     Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        //     rb.MoveRotation(localRotation);
        // }




    }

}