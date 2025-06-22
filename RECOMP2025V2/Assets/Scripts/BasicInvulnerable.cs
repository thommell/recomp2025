using System;
using UnityEngine;

public class BasicInvulnerable : MonoBehaviour {
    [SerializeField] private float invulnerableTime;
    [SerializeField] private bool isInvulnerable;
    private float originalInvulnerableTime;
    public bool IsInvulnerable => isInvulnerable;

    private void Awake() {
        originalInvulnerableTime = invulnerableTime;
    }

    private void Update() {
        if (isInvulnerable) {
            InvulnerabilityTimer();
        }
    }

    private void InvulnerabilityTimer() {
        invulnerableTime -= Time.deltaTime;
        if (invulnerableTime <= 0) {
            isInvulnerable = false;
            invulnerableTime = originalInvulnerableTime;
        }
    }
    public void ActivateInvulnerable() => isInvulnerable = true; 
}