using UnityEngine;
public class BasicPlayerHealth : MonoBehaviour, IHealth {
    [SerializeField] private int health;
    private Entity entity;
    public int Health { get; set; } = 10;
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    public void TakeDamage(Entity pReceiver, Entity pSender, int pDamage) {
        // Cancel damage call if entity doesn't exist
        if (!entity) return;
        // Cancel damage call if entity is invulnerable
        if (entity.Invulnerable.IsInvulnerable) return;
        Health -= pDamage;
        entity.Invulnerable.ActivateInvulnerable();
        Debug.Log($"{gameObject.name} took damage: {pDamage}, current health: {Health}!");
        // Check if Entity has zero or under zero health.
        if (Health <= 0) {
            entity.RequestDeath();
        }
    }
    public void Die() {
        gameObject.SetActive(false);
    }
}
