using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    public float BulletSpeed { get; private set; }
    public void SetBulletSpeed(float pSpeed) => BulletSpeed = pSpeed;
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}