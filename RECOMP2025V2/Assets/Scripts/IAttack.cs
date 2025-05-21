using UnityEngine;

public interface IAttack {
    public int Damage { get; set; }
    public void Attack(int pDamage);
}
