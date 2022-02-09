using UnityEngine;

public class BetterJumpEK : MonoBehaviour {

    [Range(1, 10)] public float jumpVelocity;
    [SerializeField] float fallMultiplier = 2.5f, lowJumpMultiplier = 2f;

    Rigidbody rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            rigidBody.velocity = Vector3.up * jumpVelocity;
        }

        if (rigidBody.velocity.y < 0) {
            rigidBody.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        } else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump")) {
            rigidBody.velocity += Vector3.up * (Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        }
    }
}
