using BulletManager;
using UnityEngine;

public interface IBullet {
    public Bullet Bullet { get; set; }
    public float BulletSpeed { get; set; }
    public int BulletDamage { get; set; }
    public bool IsFired { get; set; }
    void BulletMovement(Vector2 pDirection);
    void BulletHit();
}