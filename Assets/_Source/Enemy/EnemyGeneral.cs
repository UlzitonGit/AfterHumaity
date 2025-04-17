using UnityEngine;
using System.Collections;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] public float rageRadius = 20f;
    [SerializeField] private float attackRadius = 3f;
    [SerializeField] private float attackDuration = 1f;
    public SpriteRenderer spriteRenderer;

    public PlayerMovement player;
    private Rigidbody2D rb;
    private bool canAttack = true;

    protected void Start()
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
        Debug.Log(inAttackZone && canAttack);

        if (inAttackZone && canAttack)
        {
            Attack();
            StartCoroutine(AttackCooldown());
        }
    }

    private void MoveTowardsPlayer(float distance)
    {
        float direction = distance < 0 ? 2 : -2;
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        transform.localScale = new Vector3(direction, 2, 2);
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDuration);
        canAttack = true;
    }
    public virtual void Attack() { }
}