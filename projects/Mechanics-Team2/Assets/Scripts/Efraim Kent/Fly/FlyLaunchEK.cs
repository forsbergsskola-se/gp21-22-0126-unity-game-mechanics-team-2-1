using UnityEngine;

public interface IFly {
    void Flying(bool flying);
}

public class FlyLaunchEK : MonoBehaviour, IGrounded, IFly {

    [SerializeField] float flightSpeed = 20f, dropSpeed = 10f, maxSpeed = 30f;

    GameObject player;
    Rigidbody rigidBody;

    bool isFlying;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        isFlying = false;
    }

    void LateUpdate() {
        Launch();

        FlightAcceleration();
    }

    void FlightAcceleration() {
        var currentVelocity = rigidBody.velocity.magnitude;

        if (!isFlying && currentVelocity < maxSpeed) return;
        if (Input.GetKey(KeyCode.W)) {
            rigidBody.AddForce(Vector3.up * flightSpeed);
        }

        if (Input.GetKey(KeyCode.S)) {
            rigidBody.AddForce(Vector3.down * dropSpeed);
        }
    }

    void Launch() {
        if (Input.GetKeyDown(KeyCode.E) && !isFlying) {
            FlightMode(false);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            FlightMode(true);
        }
    }

    void FlightMode(bool isGrounded) {
        if (!isGrounded) {
            Flying(true);
        } else {
         Grounded(true);
        }
    }

    public void Grounded(bool grounded) {
        rigidBody.useGravity = true;
        isFlying = false;
        Debug.Log("Grounded");
    }

    public void Flying(bool flying) {
        rigidBody.useGravity = false;
        isFlying = true;
        Debug.Log("Flying");
    }
}
