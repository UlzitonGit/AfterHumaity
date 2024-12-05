using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private FirstEnemy firstEnemy;
    private bool canTakeDamage = true;

    private void Start()
    {
        firstEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FirstEnemy>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("AttackZone") && canTakeDamage)
        {
            StartCoroutine(DamageCooldown());
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth -= firstEnemy.damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(firstEnemy.attackCooldown);
        canTakeDamage = true;
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}