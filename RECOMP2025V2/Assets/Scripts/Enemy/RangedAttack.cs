using System;
using BulletManager;
using Unity.VisualScripting;
using UnityEngine;

public class RangedAttack : MonoBehaviour, IAttack {
    [SerializeField] private float originalTime;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;

    private Player player;
    private Entity shooter;
    private float deltaTime;

    private Vector2 playerDir;
    
    public int Damage { get; set; } 
    private void Start() {
        player = FindObjectOfType<Player>();
        shooter = GetComponent<Entity>();
        deltaTime = originalTime;
    }
    public void Attack(int pDamage) {
    }
    private void Update() {
        Timer();
    }
    private void Timer() {
        if (deltaTime <= 0) {
            deltaTime = originalTime;
            Shoot();
        }
        deltaTime -= Time.deltaTime;
    }
 
    private void Shoot() {
       
        //Bullet bulletObj = Instantiate(bulletPrefab, new Vector2(transform.position.x + playerDir.x, transform.position.y + playerDir.y), Quaternion.identity).GetComponent<Bullet>(); 
        //bulletObj.TargetOnPlayer(playerDir);
        //bulletObj.InitializeBullet(bulletObj);
        
        Debug.Log($"{gameObject.name} has shot a ranged attack!");
        playerDir = (player.transform.position - shooter.transform.position).normalized; 
        Vector2 bulletSpawnPosition = new Vector2(shooter.transform.position.x + playerDir.x, shooter.transform.position.y + playerDir.y);
        GameObject tempbullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        Bullet bullet = tempbullet.GetComponent<Bullet>();
        bullet.TargetOnPlayer(playerDir);
        bullet.CachedBulletSpeed = bulletSpeed;
        bullet.CachedBulletDamage = bulletDamage;
        
       // bullet.SetBulletSpeed(bulletSpeed);
       // bullet.SetDirection(directionToPlayer);
    }
}