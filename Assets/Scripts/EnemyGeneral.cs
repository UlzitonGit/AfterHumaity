using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement player;
    bool isRaged = false;
    bool inAttackZone = false;
    bool canAttack = true;
    Rigidbody2D rb;
    [SerializeField] float speed = 2;
    [SerializeField] float rageRadius = 20;
    [SerializeField] float attackRadius = 3;
    [SerializeField] float attackDuration = 1;
    float distanceBetweenPlayer;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenPlayer = transform.position.x - player.transform.position.x;
        isRaged = Mathf.Abs(distanceBetweenPlayer) <= rageRadius;
        inAttackZone = Mathf.Abs(distanceBetweenPlayer) <= attackRadius;
        if(isRaged == true && distanceBetweenPlayer < 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (isRaged == true && distanceBetweenPlayer > 0)
        {
           
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inAttackZone == true && canAttack == true)
        {
            Attack();
            StartCoroutine(AttackReloading());
        }
       
    }
    IEnumerator AttackReloading()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDuration);
        canAttack = true;
    }
    public virtual void Attack()
    {
        
    }
}
