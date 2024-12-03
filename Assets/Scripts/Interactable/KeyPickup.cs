using UnityEngine;

public class KeyPickup : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("Player"))
      {
        DoorController doorController = FindAnyObjectByType<DoorController>();
        if (doorController != null)
        {
          doorController.CollectKey();
        }
        Destroy(gameObject);
      }
  }
}
