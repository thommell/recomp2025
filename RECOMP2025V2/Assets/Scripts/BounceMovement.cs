using UnityEngine;
public class BounceMovement : MonoBehaviour, IKnockable {
    [SerializeField] private float deltaTime;
    [SerializeField] private float force;
    [SerializeField] private LayerMask groundLayer;
    private float originalTime;
    private bool isGrounded;
    private Entity bouncer;
    private BoxCollider2D collider; 

    private void Awake() {
        bouncer = GetComponent<Entity>();
        collider = GetComponent<BoxCollider2D>();
        originalTime = deltaTime;
    }
    public void Update() {
        CastVerticalRay();
        Timer();
    }
    private void Timer() {
        if (deltaTime <= 0 && isGrounded) {
            deltaTime = originalTime;
            SendBounce();
        }
        deltaTime -= Time.deltaTime;
    }
    private void SendBounce() {
        bouncer.RequestKnockBack(this, bouncer, GetPlayerPos(), force);  
    }
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        // Player position caching
        bouncer.RigidBody.AddForce(new Vector2(pDirection.x, pForce) * pForce, forceMode);
    }
    private Vector2 GetPlayerPos() => (StaticManager.Instance.Player.transform.position - bouncer.transform.position).normalized;
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.GetComponent<BoxCollider2D>().IsTouchingLayers()) {
            Debug.Log($"{gameObject.name} has bounced!");
            isGrounded = false;
        }
    }
    private void CastVerticalRay() {
        Vector3 rayCastPosition = bouncer.transform.position;
        float rayCastLength = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector3.down * rayCastLength);
        Debug.DrawRay(rayCastPosition, Vector3.down * rayCastLength, Color.blue);
        
        // Check if raycast is hitting the ground layer, if so set isGrounded to true.
        if (hit.collider.IsTouchingLayers(groundLayer)) {
            isGrounded = true;
            Debug.Log($"{gameObject.name} has grounded!");
        }
    }
}
