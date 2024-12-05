using UnityEngine;

public class KeyPickup : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      DoorController doorController = FindObjectOfType<DoorController>();
      doorController?.CollectKey();
      Destroy(gameObject);
    }
  }
}