using UnityEngine;
public class BasicPlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;
    private Vector2 playerDirection;
    private Player player;
    private void Awake() {
        player = GetComponent<Player>();
    }
    private void FixedUpdate() {
        PlayerMovement(GetDirection());
    }
    private void PlayerMovement(Vector2 pDirection) {
        if (pDirection == Vector2.zero || !player.CanMove) return;
        player.RequestMovement(this, pDirection, speed);
    }
    public void Move(Vector3 pDirection, float pSpeed = 1f) {
        player.transform.Translate(pDirection * (pSpeed * Time.deltaTime));
    }
    private Vector2 GetDirection() {
        Vector2 newDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) newDirection.x -= 1f;
        if (Input.GetKey(KeyCode.D)) newDirection.x += 1f;

        if (newDirection == Vector2.zero) return Vector2.zero;
        return newDirection.normalized;
    }
}
