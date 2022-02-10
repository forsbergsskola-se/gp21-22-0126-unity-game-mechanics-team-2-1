using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody) {
            //SceneManager.LoadScene("Level2");
        }
    }
}
