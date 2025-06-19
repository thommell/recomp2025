public interface IStunner {
    public float DeltaTime { get; set; }
    public bool IsStunned { get; set; }
    public void Stun();
}