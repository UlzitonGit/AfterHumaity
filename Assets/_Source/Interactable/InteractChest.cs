using UnityEngine;
using TMPro;

public class InteractChest : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] int score;
    [SerializeField] PlayerSoundController soundController;
    bool playerInRange = false;
    bool isOpened = false;
    GameObject player;
    private GameManager gameManager;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey) && !isOpened)
        {
            OpenChest();
        }
    }
    private void OpenChest()
    {
        soundController.PlayChestSound();
        isOpened = true;
        animator.SetTrigger("Play");
        gameManager.score += score;
        scoreText.text = "Score: " + gameManager.score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}