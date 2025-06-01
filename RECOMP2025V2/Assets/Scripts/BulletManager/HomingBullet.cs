using UnityEngine;

public class HomingBullet : Bullet, IBullet {
    private float homingStrength = 2.24f;
    public bool IsFired { get; set; }

    public void BulletMovement(Bullet pBullet, Vector2 pDirection) {
        Vector2 toPlayer = StaticManager.Instance.Player.transform.position - transform.position;
        Vector2 desiredDirection = toPlayer.normalized;
        Vector2 newDirection = Vector2.Lerp(direction, desiredDirection, homingStrength * Time.deltaTime).normalized;
        SetDirection(newDirection);
        pBullet.transform.Translate(Direction * (shooter.BulletSpeed * Time.deltaTime));
    }
    public void BulletHit(Bullet pBullet) {
        Destroy(pBullet.gameObject);
    }

}