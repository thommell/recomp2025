using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    // Objects
    protected RangedAttack shooter;
    private IBullet bulletScript;
    
    public IBullet BulletScript => bulletScript;
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }

    public virtual void Update() {
        if (bulletScript == null || !bulletScript.IsFired) return;
        RequestBulletMovement(Direction);
    }
    private void RequestBulletMovement(Vector2 pDirection) {
        bulletScript?.BulletMovement(this, pDirection);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity || entity.GetComponent<Bullet>()) {
            Destroy(gameObject);
            return;
        }
        
        // Short fix to prevent an IBullet
        // implementation calling RequestAttack
        // while they shouldn't be able to
        if (bulletScript == null) return;
        
        RequestAttack(entity, this, shooter.BulletDamage);
        bulletScript?.BulletHit(this);
    }
    public void AssignObject(IBullet pBulletScript) {
        SetBulletScript(pBulletScript);
    }
    public IBullet GetBulletScript() => bulletScript;
    private void SetBulletScript(IBullet pScript) => bulletScript = pScript;
    public void SetShooter(RangedAttack pShooter) => shooter = pShooter;
}