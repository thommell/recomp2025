using UnityEngine;
public class Entity : MonoBehaviour
{
    // Variables
    private IAttack attack;
    private IMovement movement;
    private IHealth health;
    private Rigidbody2D rigidbody;
    private CircleCollider2D hitbox;

    protected Vector2 direction = Vector2.zero;
    
    // Properties
    public Rigidbody2D RigidBody { get => rigidbody; set => rigidbody = value; }
    public Vector2 Direction { get => direction; }
    //Initialize
    public virtual void Awake() {
        attack = GetComponentInChildren<IAttack>();
        movement = GetComponentInChildren<IMovement>();
        health = GetComponentInChildren<IHealth>();
        rigidbody = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
    }
    // Request API
    public void RequestMovement(Vector2 pDirection, float pSpeed = 1f) {
        // Check if Entity gets a new direction.
        if (pDirection != direction) {
            direction = SetDirection(pDirection.x, pDirection.y);
        }
        
        movement?.Move(pDirection, pSpeed);
    }
    public void RequestAddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D = ForceMode2D.Impulse) {
        movement?.AddForce(pDirection, pForce, pForceMode2D);
    }
    public void RequestAttack(Entity pReceiver, int pDamage) {
        pReceiver.health?.TakeDamage(pDamage);
    }
    public void RequestHeal(int pHealth) {
        health?.TakeDamage(pHealth);
    }
    public void RequestDeath() {
        health?.Die();
    }

    /// <summary>
    /// Set the Entity's direction.
    /// </summary>
    /// <param name="pX">Horizontal direction.</param>
    /// <param name="pY">Vertical direction.</param>
    /// <returns></returns>
    public Vector2 SetDirection(float pX = 0f, float pY = 0f) {
        return new Vector2(pX, pY);
    }

    public void SetDirection(Vector2 pDirection) {
        direction = pDirection;
    }
}
