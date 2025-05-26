using System;
using UnityEngine;
public class RangedAttack : MonoBehaviour, IAttack {
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;

    private Player player;
    private Entity shooter;
    private int bulletAmount;
    private Type selectedBulletType;
    [SerializeField] private float deltaTime;
    private Vector2 cachedPlayerDirection;
    private float originalTime;
    public int Damage { get; set; } = 2;
    private void Awake() {
        shooter = GetComponent<Entity>();
        player = FindObjectOfType<Player>();
        
        originalTime = deltaTime;
    }
    public void Attack(int pDamage) {
    }
    private void Update() {
        if (!player) return;
        Timer();
    }
    private void Timer() {
        if (deltaTime <= 0) {
            deltaTime = originalTime;
            Shoot();
        }
        deltaTime -= Time.deltaTime;
    }
    private void TargetOnPlayer() => cachedPlayerDirection = (player.transform.position - shooter.transform.position).normalized;
 
    private void Shoot() {
        Debug.Log($"{gameObject.name} has shot a ranged attack!");
        TargetOnPlayer();
        Vector2 bulletSpawnPosition = new Vector2(shooter.transform.position.x + cachedPlayerDirection.x, shooter.transform.position.y + cachedPlayerDirection.y);
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        // Find the bullet of the new instantiated bullet
        Bullet newBulletObj = newBullet.GetComponent<Bullet>();
        // Find IBullet variation from the new instantiated bullet
        IBullet newBulletScript = newBulletObj.GetComponent<IBullet>();
        GetBulletType(newBulletObj);
        SetBulletValues(newBulletObj, newBulletScript);
    }

    private void SetBulletValues(Bullet pBullet, IBullet pScript) { 
        //pBullet.gameObject.AddComponent(selectedBulletType);
        pBullet.SetDirection(cachedPlayerDirection);
        pBullet.AssignObject(pScript, pBullet);
        pBullet.BulletScript.IsFired = true;
    }
    private void GetBulletType(Bullet pBullet) {
        
        switch (pBullet.GetComponent<IBullet>()) {
            case BasicBullet:
                SetBulletType<BasicBullet>();
                break;
            case HomingMovement:
                SetBulletType<HomingMovement>();
                break;
            default:
                Debug.Log("What the hell, what the helly?");
                break;
        }
    }
    private void SetBulletType<T>() where T : MonoBehaviour, IBullet {
        selectedBulletType = typeof(T);
    }
}