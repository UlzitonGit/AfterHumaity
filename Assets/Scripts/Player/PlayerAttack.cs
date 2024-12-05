using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackZone;
    [SerializeField] private float attackCooldown = 0.7f;
    private bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackZone.SetActive(false);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}