using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] float damage = 10;
    public float damageRate = 1;
    bool canDamage = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canDamage == true)
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
        }
    }
    IEnumerator Damage()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageRate);
        canDamage = true;
    }
}
