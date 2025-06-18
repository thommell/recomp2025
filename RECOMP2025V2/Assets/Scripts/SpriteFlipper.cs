using System;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour, IFlipper {
    private SpriteRenderer renderer;
    private IFlipper flipperImplementation;
    public bool IsFlipped { get; set; }
    private void Awake() {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void CheckEntityNewDirection(Vector2 newDirection) {
        if (newDirection.x >= 0.1f) IsFlipped = true;
        else if (newDirection.x <= -0.1f) IsFlipped = false;
        FlipX(IsFlipped);
    }
   
    public void FlipX(bool pFlipped) {
        renderer.flipX = pFlipped; 
    }
}