public interface IHealth {
    public int Health { get; set; }
    public void TakeDamage(Entity pSender, int pDamage);
    public void Heal(int pHeal);
    public void Die();
}
