using Unity.Mathematics;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    Rigidbody rb;

    public new Transform camera;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotaionSpeed = 600f;

    [Header ("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatisGround;

    bool grounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

  
    void Update()
    {
        // Get keyboard inputs

        float hInput = Input.GetAxisRaw("Horizontal");

        float vInput = Input.GetAxisRaw("Vertical");

        Vector3 forwardVector = new Vector3(camera.forward.x, 0f, camera.forward.z).normalized;
        Vector3 rightVector = new Vector3(camera.right.x, 0f, camera.right.z).normalized;

        // Vector describing how much we want to move
        Vector3 moveVector = (forwardVector * vInput) + (rightVector * hInput);

        // Avoids speedy diagonals above 1
        if (moveVector.magnitude > 1)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Checks if player is on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatisGround);

        float verticalSpeed = rb.linearVelocity.y;

        // Moves and rotates player
        if (grounded)
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);

        if (moveVector.magnitude > 0.2f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotaionSpeed * Time.deltaTime);
        }

    }
}
