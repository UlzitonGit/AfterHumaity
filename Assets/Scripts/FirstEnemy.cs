using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstEnemy : EnemyGeneral
{
    public int damage = 10;
    public float attackcooldown = 1.0f;

    private float nextAttackTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Time.time > nextAttackTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
    [SerializeField] GameObject attackZone;
  
    public override void Attack()
    {
        StartCoroutine(Attacking());
    }
    
    IEnumerator Attacking()
    {
        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackZone.SetActive(false);
    }
}
