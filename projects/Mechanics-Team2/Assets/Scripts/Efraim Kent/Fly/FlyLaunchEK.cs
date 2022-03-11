using UnityEngine;

public interface IFly {
    void Flying(bool flying);
}
public class FlyLaunchEK : MonoBehaviour, IFly {

    [SerializeField] float flightSpeed = 20f, dropSpeed = 10f, maxSpeed = 30f;
    Rigidbody playerRigidBody;

    bool isFlying;

    void Awake() {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void LateUpdate() {
        FlightMode();
        FlightAcceleration();
    }

    void FlightAcceleration() {
        var currentVelocity = playerRigidBody.velocity.magnitude;

        if (!isFlying && currentVelocity < maxSpeed) return;
        if (Input.GetKey(KeyCode.W)) {
            playerRigidBody.AddForce(Vector3.up * flightSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            playerRigidBody.AddForce(Vector3.down * dropSpeed);
        }
    }

    void FlightMode() {
        if (Input.GetKeyDown(KeyCode.E) && !isFlying) {
            Flying(true);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Flying(false);
        }
    }

    public void Flying(bool flying) {
        playerRigidBody.velocity = Vector3.zero;
        if (flying) {
            playerRigidBody.useGravity = false;
            isFlying = true;
            //Debug.Log("Flying is " + isFlying);
        } else {
            playerRigidBody.useGravity = true;
            isFlying = false;
            //Debug.Log("Flying is " + isFlying);
        }
    }
}
