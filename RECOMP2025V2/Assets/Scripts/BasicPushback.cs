using UnityEngine;
public class BasicPushback : MonoBehaviour, IKnockable {
    private Entity entity;
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        entity.RigidBody.AddForce(pDirection * pForce, forceMode);
        Debug.Log($"{gameObject.name} has been knocked back!");
    }
}