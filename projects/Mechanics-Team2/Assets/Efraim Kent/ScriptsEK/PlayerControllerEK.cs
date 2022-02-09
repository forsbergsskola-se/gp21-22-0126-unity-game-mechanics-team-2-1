using UnityEngine;

public interface IGrounded {
    void Grounded(bool isGrounded);
}

public class PlayerControllerEK : MonoBehaviour, IFly {

    [SerializeField] float moveSpeed = 5f, runSpeed = 10f, fallMultiplier = 2.5f, lowJumpMultiplier = 2f;
    [SerializeField, Range(1, 10)] float jumpVelocity = 6;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void LateUpdate() {
        Move();
        Jump();
    }

    void Move() {
        //Get move input
        var moveInput = Input.GetAxis("Horizontal");
        //var moveInputY = Input.GetAxis("Vertical");
        //Preferably get input in Update()

        //Set run velocity
        var velocity = rigidBody.velocity; //avoid direct repeat access to vector
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S)) {
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

            //Apply jump velocity
            if (jumpInput && IsGrounded()) {
                rigidBody.velocity = Vector3.up * jumpVelocity;
            }
            //Preferably interact with physics in FixedUpdate()

            //apply fallMultiplier to gravity
            if (rigidBody.velocity.y < 0) {
                rigidBody.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            } else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump")) {
                rigidBody.velocity += Vector3.up * (Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
                //apply lowJumpMultiplier when not holding the jump button
            }
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    public void Flying(bool isFlying) {
        if (isFlying) {
            jumpVelocity = 0;
        }
    }
}
