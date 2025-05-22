using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour, IAttack {
    private Entity shooter;
    private Player player;
    private IBullet bulletScript;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float deltaTime;
    private Vector2 directionToPlayer;
    private float originalTime;
    public int Damage { get; set; } = 2;
    private void Awake() {
        shooter = GetComponent<Entity>();
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
        Vector2 bulletSpawnPosition = new Vector2(shooter.transform.position.x + directionToPlayer.x, shooter.transform.position.y + directionToPlayer.y);
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        bulletScript = shooter.GetComponent<IBullet>();
        bulletScript.Owner = newBullet.GetComponent<Bullet>();
        bulletScript.IsFired = true;
        bulletScript.Owner.SetDirection(directionToPlayer);
    }
}