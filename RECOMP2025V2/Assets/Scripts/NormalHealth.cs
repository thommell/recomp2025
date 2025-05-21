using UnityEngine;

public class NormalHealth : MonoBehaviour, IHealth
{
    // Variables
    private Entity entity;
    
    // Properties
    public int Health { get; set; } = 10;
    
    // Methods
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    public void TakeDamage(int pDamage) {
        Health -= pDamage;
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        //TODO: Fix incoming entity call, enemy is always null for some reason (Knockback).
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