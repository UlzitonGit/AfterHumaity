using UnityEngine;

public class PlayerHealthService : IHealthService
{
    private int _currentHealth;
    private int _maxHealth;
    private readonly HealthBar _healthBar;

    public PlayerHealthService(int maxHealth, HealthBar healthBar)
    {
        _maxHealth = maxHealth;
        _healthBar = healthBar;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        _healthBar.SetHealth(_currentHealth);
    }

    public bool IsAlive() => _currentHealth > 0;
}