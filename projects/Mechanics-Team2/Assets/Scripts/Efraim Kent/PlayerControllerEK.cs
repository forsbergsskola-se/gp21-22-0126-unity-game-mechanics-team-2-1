using UnityEngine;

public class PlayerControllerEK : MonoBehaviour, IFly
{

    [SerializeField] public float moveSpeed = 5f, runSpeed = 10f, fallMultiplier = 2.5f, lowJumpMultiplier = 2f;
    [SerializeField, Range(1, 10)] float jumpVelocity = 6;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    protected bool isFlying;
    protected bool toggle;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void LateUpdate() {
        ToggleRun();
        Move();
        Jump();
    }

    void ToggleRun() {
        var runInput = Input.GetKeyDown(KeyCode.LeftCommand);
        if (runInput) {
            toggle = !toggle;
            Debug.Log($"ToggleRun is {toggle}");
        }
    }

    void Move() {
        //Get move input
        var moveInput = Input.GetAxis("Horizontal");

        //toggle movement speed
        if (toggle) { //run
            rigidBody.velocity = new Vector3(moveInput * runSpeed, rigidBody.velocity.y, 0);
        } else { //walk
            rigidBody.velocity = new Vector3(moveInput * moveSpeed, rigidBody.velocity.y, 0);
        }
    }

    void Jump() {
            //Get jump input
            var jump = Input.GetKey(KeyCode.Space);

            //Apply jump velocity
            if (jump && IsGrounded() && !isFlying) {
                rigidBody.velocity = Vector3.up * jumpVelocity;
            }

            if (rigidBody.velocity.y < 0 && !isFlying) {
                //apply fallMultiplier to gravity
                rigidBody.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            } else if (rigidBody.velocity.y > 0 && !isFlying && !jump) {
                //apply lowJumpMultiplier when not holding the jump button
                rigidBody.velocity += Vector3.up * (Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            }
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    public void Flying(bool flying) {
        isFlying = flying;
    }
}
