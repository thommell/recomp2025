using UnityEngine;

public class Player : Entity
{
    // Variables
    private Vector2 playerDirection;
    
    // Properties
    public Vector2 PlayerDirection { get => playerDirection; private set => playerDirection = value; }
    /// <summary>
    /// This sets the Player's direction safely.
    /// </summary>
    /// <param name="pDirection">The new direction.</param>
    /// <returns></returns>
    public Vector2 SetPlayerDirection(Vector2 pDirection) => playerDirection = pDirection;
}