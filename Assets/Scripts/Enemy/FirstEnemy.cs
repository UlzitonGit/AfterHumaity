using System.Collections;
using UnityEngine;

public class FirstEnemy : EnemyGeneral
{
    public int damage = 10;
    public float attackCooldown = 1.0f;
    
    public int score = 125;

    private float nextAttackTime = 0f;
    
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
