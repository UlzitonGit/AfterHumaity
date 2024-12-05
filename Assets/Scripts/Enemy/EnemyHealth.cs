using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem flame;
    [SerializeField] private float health = 100f;
    private FirstEnemy firstEnemy;
    private GameManager gameManager;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        firstEnemy = GetComponent<FirstEnemy>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameManager.score += firstEnemy.score;
            scoreText.text = $"Score: {gameManager.score}";
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flame"))
        {
            flame.maxParticles = 2000;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Flame"))
        {
            flame.maxParticles = 0;
        }
    }
}