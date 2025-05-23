using System;
using UnityEngine;

public class BasicBullet : Bullet, IBullet {
    public float BulletSpeed { get; } = 2f;
    public int BulletDamage { get; } = 2;
    public bool IsFired { get; set; }
    private void Update() {
        if (!IsFired) return;
    }
    public void BulletMovement(Bullet pBullet, Vector2 pDirection) {
        pBullet.transform.Translate(pDirection * (BulletSpeed * Time.deltaTime));
    }
    public void BulletHit(Bullet pBullet) {
        Destroy(pBullet.gameObject);
    }
}