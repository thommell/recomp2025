using UnityEngine;
public class Entity : MonoBehaviour
{
    // Variables
    private IAttack[] attack;
    private IMovement movement;
    private IKnockable[] knockable;
    private IHealth health;
    private Rigidbody2D rigidbody;

    protected Vector2 direction = Vector2.zero;
    
    // Properties
    public Rigidbody2D RigidBody { get => rigidbody; set => rigidbody = value; }
    public Vector2 Direction { get => direction; }
    //Initialize
    public virtual void Awake() {
        attack = GetComponentsInChildren<IAttack>();
        movement = GetComponentInChildren<IMovement>();
        knockable = GetComponentsInChildren<IKnockable>();
        health = GetComponentInChildren<IHealth>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Request API
    public void RequestMovement(Vector2 pDirection, float pSpeed = 1f) {
        // Check if Entity gets a new direction.
        if (pDirection != direction) {
            direction = SetDirection(pDirection.x, pDirection.y);
        }
        
        movement?.Move(pDirection, pSpeed);
    }
    public void RequestKnockBack(IKnockable pKnockable, Entity pSender, Vector3 pDirection, float pForce, ForceMode2D pForceMode2D = ForceMode2D.Impulse) {
        // Give the enemy knock back
        // Also check if the Sender is a bullet. If true, give it the bullet's knockback
        Entity reciever = GetComponent<Entity>();
        bool isBullet = pSender.GetComponent<Bullet>();
        if (isBullet || pSender.Direction == Vector2.zero) {
            pKnockable.KnockBack(pSender.Direction, 3f);
            return;
        } 
        //pKnockable.KnockBack(-pSender.Direction, 3f);
        pKnockable.KnockBack(pDirection, pForce, pForceMode2D);
    }
    public void RequestAttack(Entity pReceiver, Entity pSender, int pDamage) {
        pReceiver.health?.TakeDamage(pSender, pDamage);
    }
    public void RequestHeal(int pHealth) {
        //health?.TakeDamage(pHealth);
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
