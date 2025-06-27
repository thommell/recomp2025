using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public class BasicPlayerHealth : MonoBehaviour, IHealth {
    [SerializeField] private int health;
    private Entity entity;
    private TextMeshProUGUI playerHealthText;
    public int Health { get; set; } = 10;
    private void Awake() {
        entity = GetComponent<Entity>();
        playerHealthText = FindPlayerUI();
    }
    public void TakeDamage(Entity pReceiver, Entity pSender, int pDamage) {
        // Cancel damage call if entity doesn't exist
        if (!entity) return;
        // Cancel damage call if entity is invulnerable
        if (entity.Invulnerable.IsInvulnerable) return;
        Health -= pDamage;
        UpdatePlayerUI();
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

    private void UpdatePlayerUI() {
        playerHealthText.text = $"Player Health: {Health}";
    }

    private TextMeshProUGUI FindPlayerUI() {
        List<TextMeshProUGUI> texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>().ToList();
        foreach (TextMeshProUGUI t in texts) {
            if (t.CompareTag($"Player")) {
                return t;
            }
        }
        return null;
    }
}
