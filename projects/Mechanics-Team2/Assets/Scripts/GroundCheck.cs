using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public bool IsGrounded { get; private set; }
    [SerializeField] private float groundCheckLength = 1f;
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask groundLayers;

    void Update() {
        CheckIfGrounded();
    }

    void CheckIfGrounded() {
        var ray = new Ray(transform.position, Vector3.down);
        IsGrounded = Physics.SphereCast(ray, groundCheckRadius, groundCheckLength, groundLayers);
    }
}
