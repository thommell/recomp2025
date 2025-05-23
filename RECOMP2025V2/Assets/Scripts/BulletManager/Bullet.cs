using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : Entity {
    // Methods
    private IBullet bulletScript;
    private Bullet bulletObject;
    
    public Bullet BulletObject => bulletObject;
    public IBullet BulletScript => bulletScript;
    public override void Awake() {
    }
    private void Start() {
        StartCoroutine(BulletLifeTime());
    }
    private void Update() {
        RequestBulletMovement(bulletObject.Direction);
    }
    public void RequestBulletMovement(Vector2 pDirection) {
        bulletScript?.BulletMovement(bulletObject, pDirection);
    }
    private IEnumerator BulletLifeTime() {
        yield return new WaitForSeconds(5f);
        Destroy(bulletObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Entity entity = other.GetComponent<Entity>();
        if (!entity || entity.GetComponent<Bullet>()) return;
        
        // Short fix to prevent an IBullet
        // implementation calling RequestAttack
        // while they shouldn't be able to
        if (this is IBullet) return;
        
        RequestAttack(entity, this, GetBulletScript().BulletDamage);
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