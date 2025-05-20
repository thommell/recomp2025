using UnityEngine;

public class BasicPlayerHealth : MonoBehaviour, IHealth
{
    // Variables
    private Player player;
    
    // Properties
    public int Health { get; set; } = 4;
    
    // Methods
    private void Awake() {
        player = GetComponent<Player>();
    }
    public void TakeDamage(int pDamage) {
        Health -= pDamage;
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        if (Health <= 0) {
            Die();
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