using System.Collections;
using UnityEngine;

public class FirstEnemy : EnemyGeneral
{
    public int damage = 10;
    public float attackCooldown = 1f;
    public int score = 125;
    [SerializeField] private GameObject attackZone;

    public override void Attack()
    {
        StartCoroutine(ExecuteAttack());
    }

    private IEnumerator ExecuteAttack()
    {
        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackZone.SetActive(false);
    }
}