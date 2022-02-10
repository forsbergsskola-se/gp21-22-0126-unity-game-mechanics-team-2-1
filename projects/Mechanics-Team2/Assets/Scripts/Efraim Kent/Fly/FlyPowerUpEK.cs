using System.Collections;
using UnityEngine;

public class FlyPowerUpEK : MonoBehaviour {

    [SerializeField] int flightSpeed, dropSpeed, duration;

    GameObject player;
    Rigidbody playerRigidbody;
    bool isFlying;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        isFlying = false;
    }

    void Update() {
        if (!isFlying) return;
        if (Input.GetKey(KeyCode.W)) { playerRigidbody.AddForce(Vector3.up * flightSpeed); }
        if (Input.GetKey(KeyCode.S)) { playerRigidbody.AddForce(Vector3.down * dropSpeed); }
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(FlyPowerUp(collision));
        }
    }

    IEnumerator FlyPowerUp(Collider collision) {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        playerRigidbody.useGravity = false;
        isFlying = true;

        yield return new WaitForSeconds(duration);

        playerRigidbody.useGravity = true;
        isFlying = false;

        Destroy(gameObject);
    }
}
