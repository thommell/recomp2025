using System;
using UnityEngine;
public class BasicPlayerJump : MonoBehaviour, IKnockable {
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float jumpForce;
    private bool isGrounded;

    private void Start() {
        layerMask = LayerMask.GetMask("Ground");
        if (jumpForce == 0f)
            jumpForce = 8f;
    }
    private void FixedUpdate() {
        CheckJump();
    }
    private void CheckJump()
    {
        CastVerticalRay();
        
        if (GetJumpKey && isGrounded) {
            Jump();
        }
    }
    private void Jump() { 
        Player player = StaticManager.Instance.Player;
        player.RequestKnockBack(this, player, Vector3.up, jumpForce);
    }
    private void CastVerticalRay()
    {
        Vector3 rayCastPosition = StaticManager.Instance.Player.transform.position;
        float rayCastLength = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector3.down * rayCastLength);
        Debug.DrawRay(rayCastPosition, Vector3.down * rayCastLength, Color.blue);
            
        // Check if raycast is hitting the ground layer, if so set isGrounded to true.
        if (hit.collider.IsTouchingLayers(layerMask)) isGrounded = true;
    }
    private bool GetJumpKey => Input.GetKey(KeyCode.Space);
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        StaticManager.Instance.Player.RigidBody.AddForce(pDirection * pForce, forceMode);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        // Set grounded to false when it stops colliding.
        isGrounded = false;
    }
}
