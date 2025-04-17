using UnityEngine;

public class SecondEnemy : EnemyGeneral
{
    [SerializeField] private float attackRange = 6f;
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private GameObject acidProjectilePrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Animator animator;

    private float lastAttackTime;
    private EnemyHealth enemyHealth;

    new void Start()
    {
        base.Start();
        enemyHealth = GetComponent<EnemyHealth>();
        rageRadius = attackRange * 1.5f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        bool playerInRange = distanceToPlayer <= attackRange;

        if (playerInRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }

        spriteRenderer.flipX = player.transform.position.x < transform.position.x;

        if (playerInRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    public override void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        GameObject projectile = Instantiate(acidProjectilePrefab, attackPoint.position, Quaternion.identity);
        AcidProjectile acid = projectile.GetComponent<AcidProjectile>();

        Vector2 direction = (player.transform.position - attackPoint.position).normalized;
        acid.SetDirection(direction, projectileSpeed);
    }
}