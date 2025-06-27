using UnityEngine;

public class TeleportingBullet : Bullet, IBullet {
    [SerializeField] private float waitTime;
    [SerializeField] private float teleportDistance = 1.5f;
    private float deltaTime;
    private Vector2 originalPlayerDir = Vector2.zero;
    public bool IsFired { get; set; }
    public void BulletMovement(Bullet pBullet, Vector3 pDirection) {
        transform.position += pDirection * teleportDistance;
    }
    public override void Start() {
        base.Start();
        deltaTime = waitTime;
    }
    public override void Update() {
        Timer();
    }
    private void Timer() {
        if (deltaTime <= 0) {
            deltaTime = waitTime;
            if (originalPlayerDir == Vector2.zero) {
                originalPlayerDir = TeleportBullet();
            }
            RequestBulletMovement(originalPlayerDir);
            Debug.Log("Teleported bullet!");
        }
        deltaTime -= Time.deltaTime;
    }
    private Vector2 TeleportBullet() {
        return (StaticManager.Instance.Player.transform.position - transform.position).normalized;
    }
    public void BulletHit(Bullet pBullet) {
        Destroy(gameObject);
    }
}