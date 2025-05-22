using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    // Methods
    private IBullet bullet;
    private Bullet bulletObject;
    public override void Awake() {
        bulletObject = GetComponent<Bullet>();
    }
    private void Start() {
        bullet = GetComponent<IBullet>();
        StartCoroutine(BulletLifeTime());
    }
    public void RequestBulletMovement(Vector2 pDirection) {
        bullet?.BulletMovement(pDirection);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(bulletObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity || entity.GetComponent<Bullet>()) return;
        RequestAttack(entity, this, bullet.BulletDamage);
        bullet?.BulletHit();
    }
}