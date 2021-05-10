using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;
    public float airMultiplier = 0.004f;
    public float jumpForce = 5f;
    public bool grounded;
    public CapsuleCollider col;
    public PhysicMaterial defaultMat;
    public PhysicMaterial stickMat;

    float playerHeight = 2f;

    float groundDrag = 6f;
    float airDrag = 0f;

    float horizontalMovement;
    float verticalMovement;

    public bool isTurning = false;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (isTurning == false)
        {
            InputHandle();
            ControlDrag();

            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);

            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
            }
        }        
    }

    private void FixedUpdate()
    {
        if(isTurning == false)
        {
            MovePlayer();
        }        
    }

    void InputHandle()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    void MovePlayer()
    {
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
        
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

}
