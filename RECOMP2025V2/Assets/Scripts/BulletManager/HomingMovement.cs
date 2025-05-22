using UnityEngine;

public class HomingMovement : MonoBehaviour, IBullet{
    public Bullet Owner { get; set; }
    public float BulletSpeed { get; }
    public int BulletDamage { get; }
    public bool IsFired { get; set; }

    public void BulletMovement(Vector2 pDirecton) {
        throw new System.NotImplementedException();
    }

    public void BulletHit() {
        throw new System.NotImplementedException();
    }
}