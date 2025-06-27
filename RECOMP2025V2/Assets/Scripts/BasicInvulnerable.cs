using System;
using UnityEngine;

public class BasicInvulnerable : MonoBehaviour {
    [SerializeField] private float invulnerableTime;
    [SerializeField] private bool isInvulnerable;
    private Entity entity;
    private float originalInvulnerableTime;
    public bool IsInvulnerable => isInvulnerable;
    private void Awake() {
        originalInvulnerableTime = invulnerableTime;
        entity = GetComponent<Entity>();
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
            entity.SpriteRenderer.color = Color.white;
        }
    }
    public void ActivateInvulnerable() {
        entity.SpriteRenderer.color = Color.gray;
        isInvulnerable = true;
    }
}