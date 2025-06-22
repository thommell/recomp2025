using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasicStunner : MonoBehaviour, IStunner {
    [SerializeField] private float stunAmount;
    private Entity entity;
    public float DeltaTime { get; set; }
    public bool IsStunned { get; set; }
    private void Awake() {
        entity = GetComponent<Entity>();
        DeltaTime = stunAmount;
    }
    public void Stun() {
        if (IsStunned) return;
        if (GetStun()) {
            ApplyStun();
        }
    }
    private void ApplyStun() {
        IsStunned = true;
        entity.ToggleMovement();
        ChangeStunColour();
    }
    public void DeStun() {
        IsStunned = false;
        entity.ToggleMovement();
        ChangeStunColour();
    }
    private void Update() {
        if (IsStunned) {
            Timer();
        }
    }
    private void Timer() {
        DeltaTime -= Time.deltaTime;
        if (DeltaTime <= 0) {
            IsStunned = false;
            DeltaTime = stunAmount;
            DeStun();
        }
    }
    private void ChangeStunColour() => entity.SpriteRenderer.color = IsStunned ? Color.gray : Color.white;
    private bool GetStun() {
        int computerRoll = Random.Range(0, 6);
        int stunRoll = Random.Range(0, 6);
        if (computerRoll == stunRoll) {
            return true;
        }
        return false;
    }
}