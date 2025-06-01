using UnityEngine;

public interface IAttack {
    public int BulletDamage { get; set; }
    public void Attack(int pDamage);
}
