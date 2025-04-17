using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem flame;
    [SerializeField] public float health = 100f;
    private FirstEnemy firstEnemy;
    private SecondEnemy secondEnemy;
    private GameManager gameManager;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        firstEnemy = GetComponent<FirstEnemy>();
        secondEnemy = GetComponent<SecondEnemy>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (firstEnemy != null)
            {
                gameManager.score += firstEnemy.score;
            }
            else if (secondEnemy != null)
            {
                gameManager.score += 150;
            }

            scoreText.text = "Score: " + gameManager.score.ToString();
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