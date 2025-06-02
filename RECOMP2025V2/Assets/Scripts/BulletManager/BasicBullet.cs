using UnityEngine;
public class BasicBullet : Bullet, IBullet {
    public bool IsFired { get; set; }
    public void BulletMovement(Bullet pBullet, Vector3 pDirection) {
        pBullet.transform.Translate(pDirection * (shooter.BulletSpeed * Time.deltaTime));
    }
    public void BulletHit(Bullet pBullet) {
        Destroy(pBullet.gameObject);
    }
}