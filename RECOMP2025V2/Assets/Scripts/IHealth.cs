using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHealth {
    public int Health { get; set; }
    public void TakeDamage(int pDamage);
    public void Heal(int pHeal);
    public void Die();
}
