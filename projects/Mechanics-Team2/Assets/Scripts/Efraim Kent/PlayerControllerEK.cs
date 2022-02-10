using UnityEngine;

public interface IGrounded {
    void Grounded(bool grounded);
}

public class PlayerControllerEK : MonoBehaviour, IFly {

    [SerializeField] public float moveSpeed = 5f, runSpeed = 10f, fallMultiplier = 2.5f, lowJumpMultiplier = 2f;
    [SerializeField, Range(1, 10)] float jumpVelocity = 6;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool toggle;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void LateUpdate() {
        ToggleRun();
        Move();
        Jump();
    }


    void ToggleRun() {
        var runInput = Input.GetKeyDown(KeyCode.R);
        if (runInput) {
            toggle = !toggle;
            Debug.Log($"ToggleRun is {toggle}");
        }
    }

    void Move() {
        //Get move input
        var moveInput = Input.GetAxis("Horizontal");

        //avoid repeat direct access to velocity vector
        var velocity = rigidBody.velocity;

        //toggle movement velocity
        if (toggle) { //run
            velocity = new Vector3(moveInput * runSpeed, velocity.y, 0);
        } else { //walk
            velocity = new Vector3(moveInput * moveSpeed, velocity.y, 0);
        }
        rigidBody.velocity = velocity;
    }

    void Jump() {
            //Get jump input
            var jumpInput = Input.GetKeyDown(KeyCode.Space);

            //Apply jump velocity
            if (jumpInput && IsGrounded()) {
                rigidBody.velocity = Vector3.up * jumpVelocity;
            }

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

    public void Flying(bool flying) {
        if (!flying) {
            IsGrounded();
        }
    }
}
