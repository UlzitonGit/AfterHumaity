public interface IHealthService
{
    void TakeDamage(int damage);
    void Heal(int amount);
    bool IsAlive();
}