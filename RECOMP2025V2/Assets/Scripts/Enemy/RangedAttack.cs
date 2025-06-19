using System;
using UnityEngine;
public class RangedAttack : MonoBehaviour, IAttack {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    private Player player;
    private Entity shooter;
    private int bulletAmount;
    [SerializeField] private float deltaTime;
    private Vector2 cachedPlayerDirection;
    private float originalTime;
    public int BulletDamage { get => bulletDamage; set => bulletDamage = value; }
    public float BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }
    public void Attack(int pDamage) {
    }
    private void Awake() {
        shooter = GetComponent<Entity>();
        player = FindObjectOfType<Player>();
        originalTime = deltaTime;
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
        if (!shooter.CanMove) return;
        Debug.Log($"{gameObject.name} has shot a ranged attack!");
        TargetOnPlayer();
        Vector2 bulletSpawnPosition = new Vector2(shooter.transform.position.x + cachedPlayerDirection.x, shooter.transform.position.y + cachedPlayerDirection.y);
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        // Find the bullet of the new instantiated bullet
        Bullet newBulletObj = newBullet.GetComponent<Bullet>();
        newBulletObj.SetShooter(this);
        // Find IBullet variation from the new instantiated bullet
        IBullet newBulletScript = newBulletObj.GetComponent<IBullet>();
        SetBulletValues(newBulletObj, newBulletScript);
        shooter.Flipper.CheckEntityNewDirection(cachedPlayerDirection);
    }
    private void SetBulletValues(Bullet pBullet, IBullet pScript) { 
        pBullet.SetDirection(cachedPlayerDirection);
        pBullet.AssignObject(pScript);
        pBullet.BulletScript.IsFired = true;
    }
}