using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] string ability;
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
