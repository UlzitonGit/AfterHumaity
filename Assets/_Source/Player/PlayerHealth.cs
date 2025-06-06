using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] int damage = 10;
    private bool canTakeDamage = true;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("AttackZone") && canTakeDamage)
        {
            StartCoroutine(DamageCooldown());
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void UpdateBar()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}