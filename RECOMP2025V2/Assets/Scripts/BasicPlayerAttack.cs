using UnityEngine;
public class BasicPlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Entity entityInRange;
    [SerializeField] private float attackRange;
    private Player player;
    public int BulletDamage { get; set; } = 2;
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void Update() {
        entityInRange = GetEntityFromRayCast();
        if (!entityInRange) return;
        if (GetAttackKey() && entityInRange) {
            player.RequestAttack(entityInRange, player, BulletDamage);
            player.RequestKnockBack(entityInRange.GetComponent<BasicPushback>(), player, player.Direction, 2f);
        }
    }
    public void Attack(int pDamage) {
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
