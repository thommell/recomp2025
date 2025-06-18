using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    // Objects
    protected RangedAttack shooter;
    private IBullet bulletScript;
    
    public IBullet BulletScript => bulletScript;
    public virtual void Start() {
        StartCoroutine(BulletLifeTime());
    }

    public virtual void Update() {
        // Cancel movement call if there's no bullet script or if the bullet hasn't been fired.
        if (bulletScript == null || !bulletScript.IsFired) return;
        RequestBulletMovement(Direction);
    }
    protected void RequestBulletMovement(Vector2 pDirection) {
        bulletScript?.BulletMovement(this, pDirection);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<BaseEnemy>()) return;
        IHealth health = other.GetComponent<IHealth>();
        Entity entity = other.GetComponent<Entity>();
        if (health != null){
            bulletScript.BulletHit(this);
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
    private void SetBulletScript(IBullet pScript) => bulletScript = pScript;
    public void SetShooter(RangedAttack pShooter) => shooter = pShooter;
}