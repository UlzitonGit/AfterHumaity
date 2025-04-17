using System.Collections;
using UnityEngine;
using TMPro;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] private string ability;
    [SerializeField] private TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(ability, 1);
            collision.GetComponent<PlayerMovement>().CheckAbilities();
            text.text = ability + " unlocked!";
            text.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}