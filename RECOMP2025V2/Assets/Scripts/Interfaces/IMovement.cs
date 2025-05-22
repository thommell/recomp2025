using UnityEngine;

public interface IMovement
{
  public void Move(Vector2 pDirection, float pSpeed = 1f);
  public void AddForce(Vector3 pDirection, float pForce, ForceMode2D pForceMode2D);
}