using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage;

    public HealthBar healthBar;

    private FirstEnemy _firstEnemy;

    private bool canAttack;

    private void Start()
    {
        canAttack = true;
        _firstEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FirstEnemy>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void TakeDamage()
    {
        currentHealth -= _firstEnemy.damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("AttackZone") && canAttack)
        {
            StartCoroutine(AttackCooldown());
            TakeDamage();
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(_firstEnemy.attackCooldown);
        canAttack = true;
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
