using System.Collections;
using UnityEngine;

public class FlyHooverEK : MonoBehaviour {
    [SerializeField] float hooverDuration = 3f, hooverVelocity = 5f;
    GameObject player;
    Rigidbody playerRigidBody;
    bool isHovering;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();
        isHovering = false;
    }

    void Update() {
        if (isHovering) {
            Vector3 p = new Vector3(0, hooverVelocity * Time.deltaTime, 0);
            player.transform.position += p;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //Debug.Log(collision + " occured");
            StartCoroutine(Hoover(collision));
        }
    }

    IEnumerator Hoover(Collision collision) {

        playerRigidBody.useGravity = false;
        // if (playerRigidBody.useGravity == false) {
        //     Debug.Log("gravity is " + playerRigidBody.useGravity);
        // }
        isHovering = true;

        yield return new WaitForSeconds(hooverDuration);

        playerRigidBody.useGravity = true;
        // if (playerRigidBody.useGravity) {
        //     Debug.Log("gravity is " + playerRigidBody.useGravity);
        // }
        isHovering = false;
    }
}
