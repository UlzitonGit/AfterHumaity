using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem flame;
    private float health = 100;
    
    private FirstEnemy _firstEnemy;
    private GameManager _gameManager;
    
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        _firstEnemy = GetComponent<FirstEnemy>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void GetDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            _gameManager.score += _firstEnemy.score;
            scoreText.text = ("Score: " + (_gameManager.score).ToString());
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Flame"))
            flame.maxParticles = 2000;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Flame")) flame.maxParticles = 0;
    }
}
