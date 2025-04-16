using UnityEngine;

public class InteractChest : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    bool playerInRange = false;
    bool isOpened = false;

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
        Debug.Log("Ok");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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