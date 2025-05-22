using UnityEngine;
public class BulletMovement : MonoBehaviour, IMovement {
    // Variables
    private Bullet bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    private void Awake() {
        bullet = GetComponent<Bullet>();
    }
    private void Update() {
    }
    public void Move(Vector2 pDirection, float pSpeed = 1) {
        transform.Translate(pDirection * pSpeed);
    }
    public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D) {
    }
}