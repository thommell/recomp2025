using UnityEngine;

public interface IMovement
{
  public void Move(Vector2 pDirection, float pSpeed = 1f);
}