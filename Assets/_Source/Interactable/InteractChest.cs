using UnityEngine;

public class InteractChest : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] private string ability;
    bool playerInRange = false;
    bool isOpened = false;
    GameObject player;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey) && !isOpened)
        {
            OpenChest();
        }
    }
    private void OpenChest()
    {
        isOpened = true;
        animator.SetTrigger("Play");
        PlayerPrefs.SetString(ability, "true");
        player.GetComponent<PlayerMovement>().CheckAbilities();
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