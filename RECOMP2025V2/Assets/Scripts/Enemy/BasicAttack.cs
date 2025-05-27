using System;
using UnityEngine;

public class BasicAttack : MonoBehaviour, IAttack, IKnockable {
    private Entity entity;
    private Entity collidedEntity;
    public int Damage { get; set; } = 2;
    public void Attack(int pDamage) {
        throw new NotImplementedException();
    }

    private void Awake() {
        entity = GetComponent<Entity>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        collidedEntity = other.gameObject.GetComponent<Entity>();
        // Return if collided object IS NOT an entity
        if (!collidedEntity) return;
        Debug.Log($"Entity collision: {collidedEntity}!");
        entity.RequestAttack(collidedEntity, entity, Damage);
        entity.RequestKnockBack(this, collidedEntity, -collidedEntity.Direction, 5f);
    }
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        collidedEntity.RigidBody.AddForce(pDirection * pForce, forceMode);
    }
}