using UnityEngine;

public class BasicPlayerPickup : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.TryGetComponent(out Pickup pickup)) return;
        // Handle pickup
        pickup.PickupHandler();
        StaticManager.Instance.Player.AddPlayerComponent<BasicPlayerJump>();
    }
}