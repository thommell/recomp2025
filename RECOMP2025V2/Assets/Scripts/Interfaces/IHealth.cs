public interface IHealth {
    public int Health { get; set; }
    public void TakeDamage(Entity pReceiver, Entity pSender, int pDamage);
    public void Die();
}
