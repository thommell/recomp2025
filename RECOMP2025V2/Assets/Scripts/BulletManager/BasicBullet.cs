using System;
using UnityEngine;

public class BasicBullet : Bullet, IBullet {
    private RangedAttack shooter;

    public override void Awake() {
        shooter = GetComponent<RangedAttack>();
        base.Awake();
    }
    public bool IsFired { get; set; }
    public void BulletMovement(Bullet pBullet, Vector2 pDirection) {
        pBullet.transform.Translate(pDirection * (shooter.BulletSpeed * Time.deltaTime));
    }
    public void BulletHit(Bullet pBullet) {
        Destroy(pBullet.gameObject);
    }
}