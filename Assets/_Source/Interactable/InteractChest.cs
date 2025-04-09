using UnityEngine;

public class InteractChest : MonoBehaviour
{
    public Animator animator;
    public string animationTrigger = "Play";
    public KeyCode interactKey = KeyCode.E;

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(interactKey))
        {
            if (animator != null)
            {
                animator.SetTrigger(animationTrigger);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
