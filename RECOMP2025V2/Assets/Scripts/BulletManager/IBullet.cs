using UnityEngine;

public interface IBullet {
    public Bullet Owner { get; set; }
    public float BulletSpeed { get; }
    public int BulletDamage { get; }
    public bool IsFired { get; set; }
    void BulletMovement(Vector2 pDirecton);
    void BulletHit();
}