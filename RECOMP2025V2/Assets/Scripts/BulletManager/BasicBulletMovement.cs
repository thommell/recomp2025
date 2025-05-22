using BulletManager;
using UnityEngine;

public class BasicBulletMovement : MonoBehaviour, IBullet {
    public Bullet Bullet { get; set; }
    public float BulletSpeed { get; set; }
    public int BulletDamage { get; set; }
    public bool IsFired { get; set; }
    public void Update() {
        if (!IsFired) return;
        Bullet.RequestBulletMovement(Bullet.CachedPlayerDir);
    }
    public void BulletMovement(Vector2 pDirection) {
        Bullet.transform.Translate(pDirection * (Bullet.CachedBulletSpeed * Time.deltaTime));
    }
    public void BulletHit() {
        throw new System.NotImplementedException();
    }
}