using UnityEngine;

public class PickupObjectTest : MonoBehaviour
{
    private bool isPlayerInTrigger = false;

    void Update()
    {
       
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject); 
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
