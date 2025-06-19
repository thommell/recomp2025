using UnityEngine;
public class Player : Entity {
    [SerializeField] private float deltaTime;
    private float originalTime;
    public override void Awake() {
        base.Awake();
        originalTime = deltaTime;
    }
    private void Update() {
        if (CanMove) {
            return;
        }
        Timer();
    }
    private void Timer() {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0) {
            ToggleEntityMovement();
            deltaTime = originalTime;
        }
    }
    public void AddPlayerComponent<T>() where T: MonoBehaviour {
        gameObject.AddComponent<T>();
    }
}