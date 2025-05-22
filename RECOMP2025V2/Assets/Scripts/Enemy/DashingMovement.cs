using System;
using UnityEngine;

public class DashingMovement : MonoBehaviour, IMovement {
    private BaseEnemy enemy;
    private Player player;
    private Vector2 dashDirection;
    [SerializeField] private int dashSpeed;
    [SerializeField] private float deltaTime;
    private float originalTime;
    private void Awake() {
        enemy = GetComponent<BaseEnemy>();
        player = FindObjectOfType<Player>();
        originalTime = deltaTime;
    }

    private void Update() {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0f) {
            Dash();
            deltaTime = originalTime;
        }
    }

    private void Dash() {
        Vector2 playerDirection = player.transform.position - transform.position;
        enemy.SetDirection(playerDirection.normalized);
        enemy.RequestAddForce(playerDirection.normalized, dashSpeed);
    }

    public void Move(Vector2 pDirection, float pSpeed = 1) {
        throw new NotImplementedException();
    }
    public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D) {
        enemy.RigidBody.AddForce(pDirection * pForce, pForceMode2D);
    }
}