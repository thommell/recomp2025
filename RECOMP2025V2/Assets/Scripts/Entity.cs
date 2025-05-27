using UnityEngine;
public class Entity : MonoBehaviour
{
    // Variables
    private IAttack[] attack;
    private IHealth health;
    private bool canMove = true;
    private Rigidbody2D rigidbody;
    private float timeTillMove;

    protected Vector2 direction = Vector2.zero;
    
    
    // Properties
    private Vector2 CachedLastInput { get; set; }
    public bool CanMove {get => canMove; private set => canMove = value; }
    public Rigidbody2D RigidBody { get => rigidbody; set => rigidbody = value; }
    public Vector2 Direction { get => direction; }
    //Initialize
    public virtual void Awake() {
        attack = GetComponentsInChildren<IAttack>();
        health = GetComponentInChildren<IHealth>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Request API
    public void RequestMovement(IMovement movement, Vector2 pDirection, float pSpeed = 1f) {
        // Check if Entity gets a new direction.
        if (pDirection != direction) 
            direction = SetDirection(pDirection.x, pDirection.y);
        if (CachedLastInput != direction && direction != Vector2.zero) 
            CachedLastInput = SetDirection(direction.x, direction.y);
        movement?.Move(pDirection, pSpeed);
    }
    /// <summary>
    /// Wrapper method for requesting a new knock-back for an <see cref="Entity"/>.
    /// </summary>
    /// <param name="pKnockable">The script sending the requested knock-back.</param>
    /// <param name="pSender">The object sending the requested knock-back.</param>
    /// <param name="pDirection">The requested direction.</param>
    /// <param name="pForce">The requested force.</param>
    /// <param name="pForceMode2D">The requested ForceMode.</param>
    public void RequestKnockBack(IKnockable pKnockable, Entity pSender, Vector3 pDirection, float pForce, ForceMode2D pForceMode2D = ForceMode2D.Impulse) {
        // Helps prevent the accumulation of different forces
        RigidBody.velocity = Vector2.zero;
        // Give the enemy knock back
        switch (pKnockable) {
            case BasicPushback: 
                pKnockable.KnockBack(pSender.Direction, pForce, pForceMode2D);
                break;
            default:
                pKnockable.KnockBack(pDirection, pForce, pForceMode2D);
                break;
        }
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
    private Vector2 SetDirection(float pX = 0f, float pY = 0f) {
        return new Vector2(pX, pY);
    }
    protected void ToggleEntityMovement() => CanMove = !CanMove;
    public void SetDirection(Vector2 pDirection) {
        direction = pDirection;
    }
}
