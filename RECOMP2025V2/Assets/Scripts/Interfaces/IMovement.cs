using UnityEngine;

public interface IMovement
{
  public void Move(Vector3 pDirection, float pSpeed = 1f);
}