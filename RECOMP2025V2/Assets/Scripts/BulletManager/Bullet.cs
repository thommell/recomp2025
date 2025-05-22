using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {

    // Methods
    [SerializeField] private IBullet bulletScript;
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }
    public void RequestBulletMovement(Vector2 pDirecton) {
        bulletScript?.BulletMovement(pDirecton);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity || entity.GetComponent<Bullet>()) return;
        RequestAttack(entity, this, bulletScript.BulletDamage);
        bulletScript?.BulletHit();
    }
}