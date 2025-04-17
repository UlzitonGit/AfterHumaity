using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 7;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
        }
    }
}