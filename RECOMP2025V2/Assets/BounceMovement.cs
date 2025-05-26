using UnityEngine;

public class BounceMovement : MonoBehaviour, IKnockable {
    [SerializeField] private float deltaTime;
    [SerializeField] private float force;
    [SerializeField] private float verticalForce;
    private float originalTime;
    private Entity bouncer;
    private Player player;

    private void Awake() {
        bouncer = GetComponent<Entity>();
        player = FindObjectOfType<Player>();
        originalTime = deltaTime;
    }
    public void Update() {
        Timer();
    }

    private void Timer() {
        if (deltaTime <= 0) {
            deltaTime = originalTime;
            SendBounce();
        }
        deltaTime -= Time.deltaTime;
    }
    private void SendBounce() {
     bouncer.RequestKnockBack(this, bouncer, GetPlayerPos(), force);   
    }
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        bouncer.RigidBody.AddForce(new Vector2(pDirection.x, pForce * verticalForce) * pForce, forceMode);
    }
    private Vector2 GetPlayerPos() => player.transform.position.normalized;
}
