using UnityEngine;
public class TeleportMovement : MonoBehaviour, IMovement {
    [SerializeField] private float deltaTime;
    [SerializeField] private float teleportDistance;
    private float originalTime;
    private Entity teleporter;
    private void Awake() {
        teleporter = GetComponent<Entity>();
        originalTime = deltaTime;
    }
    private void Update() {
        Timer();
    }
    private void Timer()
    {
        if (deltaTime <= 0f) {
            deltaTime = originalTime;
            Teleport();
        }
        deltaTime -= Time.deltaTime;
    }
    private void Teleport() {
        teleporter.RequestMovement(this, GetPlayerPosition(), teleportDistance);
    }
    public void Move(Vector3 pDirection, float pSpeed = 1) {    
        float distance = Vector3.Distance(transform.position, StaticManager.Instance.Player.transform.position);
        float distanceToCancelTeleport = 2f;
        Debug.Log(distance);
        if (distance <= distanceToCancelTeleport) {
            return;
        }
        teleporter.transform.position += pDirection * pSpeed;
    }
    private Vector2 GetPlayerPosition() => (StaticManager.Instance.Player.transform.position - teleporter.transform.position).normalized;
}