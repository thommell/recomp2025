using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    // Methods
    private IBullet bulletScript;
    private Bullet bulletObject;
    
    public Bullet BulletObject => bulletObject;
    public IBullet BulletScript => bulletScript;
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }
    public virtual void Update() {
        if (bulletScript == null || !bulletObject) return;
        if (!bulletScript.IsFired) return;
        RequestBulletMovement(bulletObject.Direction);
    }
    private void RequestBulletMovement(Vector2 pDirection) {
        bulletScript?.BulletMovement(bulletObject, pDirection);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity || entity.GetComponent<Bullet>()) return;
        
        // Short fix to prevent an IBullet
        // implementation calling RequestAttack
        // while they shouldn't be able to
        if (bulletScript == null | !bulletObject) return;
        
        RequestAttack(entity, this, bulletScript.BulletDamage);
        bulletScript?.BulletHit(this);
    }
    public void AssignObject(IBullet pBulletScript, Bullet pBulletObject) {
        SetBulletObject(pBulletObject);
        SetBulletScript(pBulletScript);
        bulletObject.GetBulletObject();
    }
    public Bullet GetBulletObject() => bulletObject;
    public IBullet GetBulletScript() => bulletScript;
    private void SetBulletScript(IBullet pScript) => bulletScript = pScript;
    private void SetBulletObject(Bullet pObject) => bulletObject = pObject;
}