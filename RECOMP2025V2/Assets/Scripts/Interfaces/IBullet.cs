using UnityEngine;

public interface IBullet {
    public bool IsFired { get; set; }
    void BulletMovement(Bullet pBullet, Vector2 pDirection);
    void BulletHit(Bullet pBullet);
}