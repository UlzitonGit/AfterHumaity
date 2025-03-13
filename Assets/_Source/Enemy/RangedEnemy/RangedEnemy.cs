using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float rageRadius = 40f;
    [SerializeField] private float attackRadius = 40f;
    [SerializeField] private float attackDuration = 3f;

    private PlayerMovement player;
    private Rigidbody2D rb;
    private bool canAttack = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distanceToPlayer = transform.position.x - player.transform.position.x;
        bool isRaged = Mathf.Abs(distanceToPlayer) <= rageRadius;
        bool inAttackZone = Mathf.Abs(distanceToPlayer) <= attackRadius;

        if (isRaged)
        {
            MoveTowardsPlayer(distanceToPlayer);
        }

        if (inAttackZone && canAttack)
        {
            Attack();
            StartCoroutine(AttackCooldown());
        }
    }

    private void MoveTowardsPlayer(float distance)
    {
        float direction = distance < 0 ? 1 : -1;
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDuration);
        canAttack = true;
    }
    public virtual void Attack() { }
}
