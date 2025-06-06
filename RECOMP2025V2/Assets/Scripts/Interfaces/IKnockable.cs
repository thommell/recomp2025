using UnityEngine;
public interface IKnockable {
    /// <summary>
    /// Wrapper method for distinguishing between different <see cref="IKnockable"/> implementations.
    /// </summary>
    /// <param name="pDirection"></param>
    /// <param name="pForce"></param>
    /// <param name="forceMode"></param>
    public void KnockBack(Vector2 pDirection, float pForce, ForceMode2D forceMode = ForceMode2D.Impulse);
}