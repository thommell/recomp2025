
using UnityEngine;

public class BaseEnemy : Entity {
    public BoxCollider2D collider;
    public GameObject prefabSource;
    public int ID;
    public override void Awake() {
        base.Awake();
        collider = GetComponent<BoxCollider2D>();
    }
}