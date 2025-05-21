using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour, IAttack {
    private BaseEnemy enemy;
    private Player player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float deltaTime;
    private Vector2 directionToPlayer;
    private float originalTime;
    public int Damage { get; set; } = 2;
    private void Awake() {
        enemy = GetComponent<BaseEnemy>();
        player = FindObjectOfType<Player>();
        originalTime = deltaTime;
    }
    private void Update() {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0f) {
            Shoot();
            deltaTime = originalTime;
        }
    }
    public void Attack(int pDamage) {
    }
    private void TargetOnPlayer() {
        directionToPlayer = (player.transform.position - transform.position).normalized;
    }
    private void Shoot() {
        Debug.Log($"{gameObject.name} has shot a ranged attack!");
        TargetOnPlayer();
        Vector2 bulletSpawnPosition = new Vector2(enemy.transform.position.x + directionToPlayer.x, enemy.transform.position.y + directionToPlayer.y);
        GameObject tempbullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        Bullet bullet = tempbullet.GetComponent<Bullet>();
        AssignBullet(bullet);
    }

    private void AssignBullet(Bullet pBullet) {
        pBullet.SetDirection(directionToPlayer);
        pBullet.AssignDamage(Damage);
        pBullet.AssignSpeed(bulletSpeed);
        pBullet.AssignOwner(enemy);
    }
}