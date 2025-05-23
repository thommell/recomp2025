using UnityEngine;

public interface IBullet {
    public float BulletSpeed { get; }
    public int BulletDamage { get; }
    public bool IsFired { get; set; }
    void BulletMovement(Bullet pBullet, Vector2 pDirection);
    void BulletHit(Bullet pBullet);
}