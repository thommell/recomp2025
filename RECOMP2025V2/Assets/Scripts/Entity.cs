using UnityEngine;
public class Entity : MonoBehaviour
{
    // Variables
    private IAttack attack;
    private IMovement movement;
    private IHealth health;
    private Rigidbody2D rigidbody;
    private CircleCollider2D hitbox;
    
    // Properties
    public Rigidbody2D RigidBody { get => rigidbody; set => rigidbody = value; }
    //Initialize
    public virtual void Awake() {
        attack = GetComponentInChildren<IAttack>();
        movement = GetComponentInChildren<IMovement>();
        health = GetComponentInChildren<IHealth>();
        rigidbody = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
    }
    // Request API
    public void PerformMovement(Vector2 pDirection, float pSpeed = 1f) {
        movement?.Move(pDirection, pSpeed);
    }
    public void PerformAddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D = ForceMode2D.Impulse) {
        movement?.AddForce(pDirection, pForce, pForceMode2D);
    }
    public void PerformAttack(Entity pReceiver, int pDamage) {
        pReceiver.health?.TakeDamage(pDamage);
    }
    public void PerformHealth(int pHealth) {
        health?.TakeDamage(pHealth);
    }
    public void PerformDeath() {
        health?.Die();
    }
}
