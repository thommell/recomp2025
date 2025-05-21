using System;
using System.Net;
using UnityEngine;

public class BasicPlayerAttack : MonoBehaviour, IAttack
{
    private Player player;
    private Entity targetEntity;
    public int Damage { get; set; } = 2;
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void Update() {
        CastDirectionRay();
        if (GetAttackKey() && targetEntity is not null) {
            player.PerformAttack(targetEntity, Damage);
        }
    }
    public void Attack(int pDamage) {
    }
    private void CastDirectionRay() {
        Vector2 rayCastPosition = new Vector2(transform.position.x + 0.7f * player.PlayerDirection.x, transform.position.y);
        float rayCastLength = 1f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, player.PlayerDirection * rayCastLength);
        Debug.DrawRay(rayCastPosition, player.PlayerDirection * rayCastLength, Color.blue);
        // Return if there's not a single hit being registered.
        if (!hit) {
            targetEntity = null;
            return;
        }
        targetEntity = hit.collider.GetComponent<Entity>();
        // Could be better, quick fix.
        if (targetEntity is Player) {
            targetEntity = null;
        }
        // Return if there's not a valid Entity being hit.
        // if (!entityHit) return;
        // targetEntity = entityHit;
    }

    private bool GetAttackKey() => Input.GetKeyDown(KeyCode.Tab);

}
