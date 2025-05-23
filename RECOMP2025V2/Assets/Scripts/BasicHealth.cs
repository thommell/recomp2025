using UnityEngine;

public class BasicHealth : MonoBehaviour, IHealth
{
    // Variables
    private Entity entity;
    [SerializeField] private int health;
    
    // Properties
    public int Health { get => health; set => health = value; }
    
    // Methods
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    public void TakeDamage(Entity pSender, int pDamage) {
        Health -= pDamage;
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        //bool isBullet = pSender.GetComponent<Bullet>();
        // Give the enemy knockback
        // Also check if the Sender is a bullet. If true, don't give it knockback.
        if (entity) {
            entity.RequestAddForce(-entity.Direction, 5f);
        }
        
        // Check if Entity has zero or under zero health.
        if (Health <= 0) {
            entity.RequestDeath();
        }
    }
    public void Heal(int pHeal) {
        Debug.Log($"Player received some healing: {pHeal}, new health: {Health}!");
        Health += pHeal;
        if (Health > 6) {
            Health = 6;
        }
    }
    public void Die() {
        Destroy(gameObject);
    }
}