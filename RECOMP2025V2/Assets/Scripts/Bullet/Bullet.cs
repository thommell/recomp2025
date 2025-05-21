using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    private Entity owner;
    private int bulletDamage;
    private float bulletSpeed;
    
    // Properties
    public float BulletSpeed => bulletSpeed;
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    public void AssignDamage(int pDamage) {
        bulletDamage = pDamage;
    }
    public void AssignSpeed(float pSpeed) {
        bulletSpeed = pSpeed;
    }
    public void AssignOwner(Entity pOwner) {
        owner = pOwner;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity) return;
        RequestAttack(entity, owner, bulletDamage);
        Destroy(gameObject);
    }
}