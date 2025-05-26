using System;
using UnityEngine;

public class BasicAttack : MonoBehaviour, IAttack {
    private Entity entity;
    public int Damage { get; set; } = 2;

    private void Awake() {
        entity = GetComponent<Entity>();
    }

    public void Attack(int pDamage) {
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        Entity collidedEntity = other.gameObject.GetComponent<Entity>();
        // Return if collided object IS NOT an entity
        if (!collidedEntity) return;
        Debug.Log($"Entity collision: {collidedEntity}!");
        entity.RequestAttack(collidedEntity, entity, Damage);
    }
}