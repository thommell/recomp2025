using UnityEngine;

public interface IKnockable {
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse);
}