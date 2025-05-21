using UnityEngine;

public class BaseEnemy : Entity {
    public void TakeKnockback(Vector3 pDirection, float pForce, ForceMode2D pForceMode) {
        RigidBody.AddForce(pDirection * pForce, pForceMode);
        Debug.Log($"{gameObject.name} has been knocked back!");
    }
}