using System.Collections;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private GameObject acidProjectilePrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage = 10;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private float phase2Threshold = 12f;
    [SerializeField] private float phase3Threshold = 24f;
    [SerializeField] private float finalPhaseDuration = 60f;

    private float battleTime = 0f;
    private int currentPhase = 1;
    private bool isInFinalPhase = false;
    private Coroutine attackCoroutine;
    private bool canMove = true;

    private float[] attackRates = { 5f, 7f, 9f };
    private int[] projectilesPerShot = { 1, 2, 3 };

    private void Start()
    {
        StartCoroutine(BattleTimer());
        attackCoroutine = StartCoroutine(AttackRoutine());
    }

    private void FixedUpdate()
    {
        if (playerTarget != null && canMove)
        {
            float directionX = Mathf.Sign(playerTarget.position.x - transform.position.x);
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        }
    }

    private IEnumerator BattleTimer()
    {
        while (!isInFinalPhase)
        {
            battleTime += Time.deltaTime;
            CheckPhaseTransition();
            yield return null;
        }

        float finalPhaseEndTime = battleTime + finalPhaseDuration;
        while (battleTime < finalPhaseEndTime)
        {
            battleTime += Time.deltaTime;
            yield return null;
        }

        moveSpeed *= 1.5f;
        attackRates[2] *= 0.8f;
    }

    private void CheckPhaseTransition()
    {
        if (battleTime >= phase3Threshold && currentPhase != 3)
        {
            EnterPhase3();
        }
        else if (battleTime >= phase2Threshold && currentPhase != 2)
        {
            EnterPhase2();
        }
    }

    private void EnterPhase2()
    {
        text.text = "Boss enters Second phase! Speed+";
        text.gameObject.SetActive(true);
        currentPhase = 2;
        moveSpeed *= 1.2f;
    }

    private void EnterPhase3()
    {
        text.text = "Boss enters Final phase! Atk+, HP-";
        text.gameObject.SetActive(true);
        currentPhase = 3;
        damage = 20;
        isInFinalPhase = true;
        gameObject.GetComponent<EnemyHealth>().health = 80;
        moveSpeed *= 1.2f;
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRates[currentPhase - 1]);

            for (int i = 0; i < projectilesPerShot[currentPhase - 1]; i++)
            {
                SpitAcid();
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    private void SpitAcid()
    {
        GameObject projectile = Instantiate(acidProjectilePrefab, attackPoint.position, Quaternion.identity);
        AcidProjectile acid = projectile.GetComponent<AcidProjectile>();
        acid.damage = damage;

        Vector2 direction = (playerTarget.position - attackPoint.position).normalized;
        acid.SetDirection(direction, 8);
    }
}