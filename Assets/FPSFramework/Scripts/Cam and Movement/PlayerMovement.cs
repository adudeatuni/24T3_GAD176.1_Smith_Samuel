using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orentation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rigidbod;
    private void Start()
    {   //Gets reference to the player rigidbody, then freezes the player's rotation (prevents them falling over)
        rigidbod = GetComponent<Rigidbody>();
        rigidbod.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //checks if player is grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        //sets the drag if player is grounded
        if (grounded)
        {
            rigidbod.drag =groundDrag;
        }
        else
        {
            rigidbod.drag = 0;
        }

        SpeedControl();
    }
    // Is called at a fixed interval, as opposed to every frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate movement direction, will always walk direction player is looking
        moveDirection = orentation.forward * verticalInput + orentation.right * horizontalInput;

        rigidbod.AddForce(moveDirection.normalized * moveSpeed * 15f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rigidbod.velocity.x, 0f, rigidbod.velocity.z);

        //if needed, limit player's velocity
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rigidbod.velocity = new Vector3(limitedVel.x, rigidbod.velocity.y, limitedVel.z);
        }
    }
}
