using System;
using UnityEngine;
public class RangedAttack : MonoBehaviour, IAttack {
    private Entity shooter;
    private Player player;
    private int bulletAmount;
    private Type selectedBulletType;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float deltaTime;
    private Vector2 directionToPlayer;
    private float originalTime;
    [SerializeField] private Bullet currentBullet;
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
        //TODO: Refactor all of this to only add IBullet on the instantiated Prefab. 
        //TODO: Remove Bullet.cs from the Bullet prefab.
        Debug.Log($"{gameObject.name} has shot a ranged attack!");
        TargetOnPlayer();
        Vector2 bulletSpawnPosition = new Vector2(shooter.transform.position.x + directionToPlayer.x, shooter.transform.position.y + directionToPlayer.y);
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        newBullet.name = $"{gameObject.name} bullet {bulletAmount}";
        
        // Find object and IBullet variation
        Bullet newBulletObj = newBullet.GetComponent<Bullet>();
        IBullet newBulletScript = GetComponent<IBullet>();
        switch (newBulletScript) {
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
        newBulletObj.gameObject.AddComponent(selectedBulletType);
        newBulletObj.AssignObject(newBulletScript, newBulletObj);
        newBulletObj.SetDirection(directionToPlayer);
        newBulletObj.GetBulletScript().IsFired = true;
    }
    private void SetBulletType<T>() where T : MonoBehaviour, IBullet {
        selectedBulletType = typeof(T);
    }
}