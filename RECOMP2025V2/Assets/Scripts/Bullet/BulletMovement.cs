using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour, IMovement {
    private Bullet bullet;


    private void Awake() {
        bullet = GetComponent<Bullet>();
    }

    private void Update() {
        bullet.RequestMovement(bullet.Direction.normalized, bullet.BulletSpeed * Time.deltaTime);
    }
        
    public void Move(Vector2 pDirection, float pSpeed = 1) {
        transform.Translate(pDirection * pSpeed);
    }
        
    public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D) {
    }
}