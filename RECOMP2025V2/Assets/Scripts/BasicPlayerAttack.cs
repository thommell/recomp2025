using System;
using System.Net;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicPlayerAttack : MonoBehaviour, IAttack
{
    private Player player;
    [SerializeField] private Entity entityInRange;
    [SerializeField] private float attackRange;
    public int Damage { get; set; } = 2;
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void Update() {
        entityInRange = GetEntityFromRayCast();
        if (entityInRange is null) return;
        if (GetAttackKey() && entityInRange) {
            player.RequestAttack(entityInRange, player, Damage);
            player.RequestKnockBack(entityInRange.GetComponent<BasicPushback>(), player, player.Direction, 5f);
        }
    }
    public void Attack(int pDamage) {
        Debug.Log("Player Attack");
    }
    private Entity GetEntityFromRayCast() {
        Vector2 rayCastPosition = new Vector2(transform.position.x + 0.7f * player.Direction.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, player.Direction.normalized, attackRange);
        Debug.DrawRay(rayCastPosition, player.Direction * attackRange, Color.blue);
        // Return if there's not a single hit being registered.
        if (!hit) {
            return null;
        }
        // Return if the collider interacts with the player
        if (hit.collider.GetComponent<Player>()) return null;
        // Return the Entity if it hits one.
        return hit.collider.GetComponent<Entity>();
    }

    private bool GetAttackKey() => Input.GetKeyDown(KeyCode.Tab);
}
