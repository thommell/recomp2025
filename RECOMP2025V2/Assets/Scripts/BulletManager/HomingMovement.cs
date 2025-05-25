using UnityEngine;

public class HomingMovement : MonoBehaviour, IBullet{
    public Bullet Owner { get; set; }
    public float BulletSpeed { get; }
    public int BulletDamage { get; }
    public bool IsFired { get; set; }
    public void BulletMovement(Bullet pBullet, Vector2 pDirection) {
        throw new System.NotImplementedException();
    }

    public void BulletHit(Bullet pBullet) {
        throw new System.NotImplementedException();
    }

    public void SetShooter(Entity pShooter) {
        throw new System.NotImplementedException();
    }
}