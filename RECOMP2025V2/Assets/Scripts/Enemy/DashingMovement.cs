using System;
using UnityEngine;

public class DashingMovement : MonoBehaviour, IKnockable {
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
        enemy.RequestKnockBack(this, enemy, enemy.Direction, dashSpeed);
    }

    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D pForceMode = ForceMode2D.Impulse) {
        enemy.RigidBody.AddForce(pDirection * pForce, pForceMode);
    }
}