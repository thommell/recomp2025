using System;
using System.Buffers;
using UnityEngine;

public class BasicBullet : Bullet, IBullet{
    public Bullet Owner { get; set; }
    public float BulletSpeed { get; } = 2f;
    public int BulletDamage { get; } = 2;
    public bool IsFired { get; set; }
    private void Update() {
        if (!IsFired) return;
        RequestBulletMovement(Owner.Direction);
    }
    public void BulletMovement(Vector2 pDirection) {
        Owner?.transform.Translate(pDirection * (BulletSpeed * Time.deltaTime));
    }
    public void BulletHit() {
        throw new NotImplementedException();
    }
}