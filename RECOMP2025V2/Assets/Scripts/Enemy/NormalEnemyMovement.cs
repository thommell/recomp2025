using System;
using System.Collections;
using Enemy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalEnemyMovement : MonoBehaviour, IMovement {
    [SerializeField] private BaseEnemy enemy;
    private Player player;
    private float moveSpeed = 1f;
    
    //TODO: Timer
    private bool isWaiting;
    private float amountToWait = 1.5f;
    private float deltaTime;

    private void Awake() {
        enemy = GetComponent<BaseEnemy>();
        player = FindObjectOfType<Player>();
        deltaTime = amountToWait;
    }
    private void FixedUpdate() {
        EnemyMovement();
    }
    private void EnemyMovement() {
        WalkTowards();
    }
    private void WalkTowards() {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        enemy.PerformMovement(directionToPlayer,moveSpeed * Time.deltaTime);
    }
    public void Move(Vector2 pDirection, float pSpeed = 1) {
        transform.Translate(pDirection * pSpeed);
    }
    public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D) {
    }
}