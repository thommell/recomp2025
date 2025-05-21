using System;
using System.Net;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicPlayerAttack : MonoBehaviour, IAttack
{
    private Player player;
    [SerializeField] private Entity entityInRange;
    public int Damage { get; set; } = 2;
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void Update() {
        entityInRange = GetEntityFromRayCast();
        if (entityInRange is null) return;
        if (GetAttackKey() && entityInRange) {
            player.RequestAttack(entityInRange, Damage);
        }
    }
    public void Attack(int pDamage) {
    }

    private Entity GetEntityFromRayCast() {
        Vector2 rayCastPosition = new Vector2(transform.position.x + 0.7f * player.Direction.x, transform.position.y);
        float rayCastLength = 1f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, player.Direction * rayCastLength);
        Debug.DrawRay(rayCastPosition, player.Direction * rayCastLength, Color.blue);
        // Return if there's not a single hit being registered.
        if (!hit) {
            return null;
        }
        // Return if the collider interacts with the player
        if (hit.collider.GetComponent<Player>()) return null;
        return hit.collider.GetComponent<Entity>();
    }

    private bool GetAttackKey() => Input.GetKeyDown(KeyCode.Tab);

}
