using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class MoveFirstPersonCamera : MonoBehaviour
{

    Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Ground Check")]
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
        // Get keyboard input

        float hInput = Input.GetAxisRaw("Horizontal");
        
        float vInput = Input.GetAxisRaw("Vertical");

        // Creates vector describing how much we want to move
        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        // Avoids speedy diagonals above 1
        if (moveVector.magnitude > 1f)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Checks if player is on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatisGround);

        // Move character
        float verticalSpeed = rb.linearVelocity.y;

        if (grounded)
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);


      
    }
}
