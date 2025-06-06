using UnityEngine;

public class StaticManager : MonoBehaviour {
    private Player player;
    public static StaticManager Instance { get; private set; }

    public Player Player {
        get {
            if (player == null) {
                player = FindObjectOfType<Player>();
            }
            return player;
        }
    }

    private void Awake() {
        if (!Instance) {
            Instance = this;
        }
        SetPlayer();
    }
    private void SetPlayer() {
        player = FindObjectOfType<Player>();
    }
    public Vector2 GetNormalizedStepValue(Vector2 pValue1, Vector2 pValue2) {
        return (pValue1 - pValue2).normalized;
    }
}