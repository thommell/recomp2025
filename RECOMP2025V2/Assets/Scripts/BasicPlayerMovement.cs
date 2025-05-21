using System;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour, IMovement
{
    private Player player;
    private float speed = 8f;
    private float jumpForce = 4.5f;
    private Vector2 playerDirection;
    private bool isGrounded;
    
    [SerializeField] private LayerMask layerMask;
    
    // Properties
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void FixedUpdate() {
        CheckJump();
        PlayerMovement(GetDirection());
    }
    private void PlayerMovement(Vector2 pDirection) {
        if (pDirection == Vector2.zero) return;
        player.RequestMovement(pDirection, speed);
    }
    private void CheckJump()
    {
        CastVerticalRay();
        //Debug.Log($"Is player currently grounded: {isGrounded}");
        
        if (GetJumpKey && isGrounded) {
            Jump();
        }
    }
    public void Move(Vector2 pDirection, float pSpeed = 1f) {
        player.transform.Translate(pDirection * (pSpeed * Time.deltaTime));
        
        // Check if current direction of player is the same as the new direction.
        if ((int)pDirection.x != (int)playerDirection.x) {
          //  player.SetPlayerDirection(pDirection);
        }
    }
    public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D) {
        player.RigidBody.AddForce(pDirection * pForce, pForceMode2D);
    }
    private void Jump() {
        player.RequestAddForce(Vector3.up, jumpForce);
    }
    private void CastVerticalRay()
    {
        Vector3 rayCastPosition = player.transform.position;
        float rayCastLength = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector3.down * rayCastLength);
        Debug.DrawRay(rayCastPosition, Vector3.down * rayCastLength, Color.blue);
        
        // Check if raycast is hitting the ground layer, if so set isGrounded to true.
        if (hit.collider.IsTouchingLayers(layerMask)) isGrounded = true;
    }
    private Vector2 GetDirection() {
        Vector2 newDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) newDirection.x -= 1f;
        if (Input.GetKey(KeyCode.D)) newDirection.x += 1f;

        if (newDirection == Vector2.zero) return Vector2.zero;
        return newDirection.normalized;
    }
    private bool GetJumpKey => Input.GetKey(KeyCode.Space);

    private void OnCollisionExit2D(Collision2D other)
    {
        // Set grounded to false when it stops colliding.
        isGrounded = false;
    }
}
