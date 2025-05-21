using UnityEngine;

public class NormalHealth : MonoBehaviour, IHealth
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
    public void TakeDamage(int pDamage) {
        Health -= pDamage;
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        BaseEnemy derivedEnemy = GetComponent<BaseEnemy>();
        
        // Give the enemy knockback
        if (derivedEnemy)
            derivedEnemy.RequestAddForce(-derivedEnemy.Direction, 5f);
        
        // Check if Entity has died.
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