using UnityEngine;

public class BasicAIMovement : MonoBehaviour, IMovement {
    [SerializeField] private BaseEnemy enemy;
    private float moveSpeed = 1f;
    
    private bool isWaiting;
    private float amountToWait = 1.5f;
    private float deltaTime;
    
    private Vector2 enemyDirection;

    private void Awake() {
        enemy = GetComponent<BaseEnemy>();
        deltaTime = amountToWait;
    }
    private void FixedUpdate() {
        EnemyMovement();
    }
    private void EnemyMovement() {
        WalkTowards();
    }
    private void WalkTowards() {
        Vector2 directionToPlayer = (StaticManager.Instance.Player.transform.position - transform.position).normalized;
        enemy.RequestMovement(this, new Vector2(directionToPlayer.x, 0f),moveSpeed * Time.deltaTime);
    }
    public void Move(Vector3 pDirection, float pSpeed = 1) {
        transform.Translate(pDirection * pSpeed);
    }
}