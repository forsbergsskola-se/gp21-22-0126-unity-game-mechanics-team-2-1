using System;
using UnityEngine;

public class PlayerControllerEK : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f, runSpeed = 10f, jumpForce = 500f;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        Move();
        Jump();
    }

    void Move() {
        //Get move input
        var moveInput = Input.GetAxis("Horizontal");
        //Preferably get input in Update()

        //Set run velocity
        var velocity = rigidBody.velocity; //avoid direct repeat access to vector
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D)) {
            velocity = new Vector3(moveInput * runSpeed, velocity.y, 0);
        } else {
            //Set walk velocity
            velocity = new Vector3(moveInput * moveSpeed, velocity.y, 0);
        }
        rigidBody.velocity = velocity;
        //Preferably interact with physics in FixedUpdate()
    }

    void Jump() {
            //Get jump input
            var jumpInput = Input.GetKeyDown(KeyCode.Space);
            //Preferably in Update()

            //Apply jump force
            if (jumpInput && IsGrounded())
                rigidBody.AddForce(Vector3.up * jumpForce);
                //Preferably interact with physics in FixedUpdate()
                //since physics run at a fixed framerate anyway
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
