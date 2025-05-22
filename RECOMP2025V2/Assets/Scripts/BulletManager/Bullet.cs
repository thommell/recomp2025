using System;
using UnityEngine;

namespace BulletManager {
    public class Bullet : MonoBehaviour {
        private IBullet bullet;
        private Vector2 cachedPlayerDir;
        
        public Vector2 CachedPlayerDir => cachedPlayerDir;
        public float CachedBulletSpeed { get; set; }
        public int CachedBulletDamage { get; set; }
        private void Awake() {
            bullet = GetComponent<IBullet>();
        }
        public void RequestBulletMovement(Vector2 pDirection) {
            bullet?.BulletMovement(pDirection);
            Debug.Log(gameObject.name);
        }
        public void TargetOnPlayer(Vector2 pDirection) {
            cachedPlayerDir = pDirection;
        }
    }
}