using System;
using UnityEngine;

public class BasicPushback : MonoBehaviour, IKnockable {
    private Entity entity;
    private void Awake() {
        entity = GetComponent<Entity>();
    }
    
    /// <summary>
    /// Wrapper method for distinguishing between different <see cref="IKnockable"/> implementations.
    /// </summary>
    /// <param name="pDirection"></param>
    /// <param name="pForce"></param>
    /// <param name="pForceMode"></param>
    public void PushBack(Vector2 pDirection, float pForce, ForceMode2D pForceMode = ForceMode2D.Impulse) => entity.RequestKnockBack(this, entity, pDirection, pForce, pForceMode);
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse) {
        entity.RigidBody.AddForce(pDirection * pForce, forceMode);
        Debug.Log($"{gameObject.name} has been knocked back!");
    }

}