using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstEnemy : EnemyGeneral
{
    [SerializeField] GameObject attackZone;
    // Start is called before the first frame update
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
