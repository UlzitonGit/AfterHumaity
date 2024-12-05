using System.Collections;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    public float damageRate = 1f;
    private bool canDamage = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canDamage)
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
            //StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageRate);
        canDamage = true;
    }
}