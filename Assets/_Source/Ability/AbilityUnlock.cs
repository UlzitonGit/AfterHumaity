using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] private string ability;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString(ability, "true");
            collision.GetComponent<PlayerMovement>().CheckAbilities();
            Destroy(gameObject);
        }
    }
}