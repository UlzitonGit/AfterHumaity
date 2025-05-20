using UnityEngine;
using UnityEngineInternal;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    public float damageRate = 1;
    private bool canDamage = true;
    public bool hit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canDamage)
        {
            hit = true;
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
        }
    }
}