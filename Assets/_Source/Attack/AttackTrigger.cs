using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    public float damageRate = 1;
    private bool canDamage = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canDamage)
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
        }
    }
}