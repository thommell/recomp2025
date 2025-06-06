using UnityEngine;

public class BasicHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int health;
    private Entity entity;
    public int Health { get => health; set => health = value; }
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    public void TakeDamage(Entity pSender, int pDamage) {
        // Cancel damage call if entity doesn't exist
        if (!entity) return;
        Health -= pDamage;
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        
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