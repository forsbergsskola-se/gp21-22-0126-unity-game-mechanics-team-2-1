using UnityEngine;

public interface IFly {
    void Flying(bool isFlying);
}

public class FlyLaunchEK : MonoBehaviour, IGrounded {

    [SerializeField] float flightSpeed = 5f, dropSpeed = 2.5f;
    GameObject player;
    Rigidbody rigidBody;
    bool isFlying;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        isFlying = false;
    }

    void LateUpdate() {
        Launch();
        if (!isFlying) return;
        if (Input.GetKey(KeyCode.W)) { rigidBody.AddForce(Vector3.up * flightSpeed, ForceMode.Acceleration); }
        if (Input.GetKey(KeyCode.S)) { rigidBody.AddForce(Vector3.down * dropSpeed); }
    }

    void Launch() {
        if (Input.GetKeyDown(KeyCode.E)) {
            FlightMode();
        }
    }

    void FlightMode() {
        if (!isFlying) {
            rigidBody.useGravity = false;
            isFlying = true;
        } else {
            rigidBody.useGravity = true;
            isFlying = false;
        }
    }

    public void Grounded(bool isGrounded) {
        if (isGrounded) {
            isFlying = false;
        }
    }
}
