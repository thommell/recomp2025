using System;
using UnityEngine;

public class NormalAttack : MonoBehaviour, IAttack {
    private Entity entity;
    public int Damage { get; set; } = 2;

    private void Awake() {
        entity = GetComponent<Entity>();
    }

    public void Attack(int pDamage) {
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        Entity collidedEntity = other.gameObject.GetComponent<Entity>();
        if (collidedEntity) {
            //entity.RequestAttack(collidedEntity, Damage);
            Debug.Log($"Entity collision: {collidedEntity}!");
            entity.RequestAttack(collidedEntity, entity, Damage);
        }
    }
}