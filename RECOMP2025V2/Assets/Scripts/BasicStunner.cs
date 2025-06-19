using System;
using UnityEngine;

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
        IsStunned = true;
    }
    private void Update() {
        if (IsStunned) {
            if (entity.CanMove)   
                entity.ToggleMovement();
            Timer();
        }
    }
    private void Timer() {
        DeltaTime -= Time.deltaTime;
        Debug.Log($"Stun duration: {DeltaTime}");
        if (DeltaTime <= 0) {
            IsStunned = false;
            DeltaTime = stunAmount;
            entity.ToggleMovement();
        }
    }
}