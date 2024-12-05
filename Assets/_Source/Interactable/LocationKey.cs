using UnityEngine;

public class LocationKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LocationDoorController doorController = FindObjectOfType<LocationDoorController>();
        doorController?.CollectKeys();
        Destroy(gameObject);
    }
}