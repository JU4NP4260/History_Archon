using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player;

    public float moveSpeed;
    public float meleeRange;
    public int EnemyHealth = 15;
    public int CurrentEnemyHealth;
    private float distToPlayer;
    private float timeBtwDamage;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustFlip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CurrentEnemyHealth = EnemyHealth;
        mustPatrol = true;
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);

        }
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= meleeRange)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();

        }

        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);

        distToPlayer = Vector2.Distance(transform.position, player.position);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bodyCollider.IsTouchingLayers(groundLayer))
        {

            transform.localScale = new Vector2(-0.2f, 0.2f);

        }
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        mustPatrol = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }


    public void TakeDamage(int damage)
    {
        CurrentEnemyHealth -= damage;
        Debug.Log("Damage TAKEN!");

        if (CurrentEnemyHealth <= 0)
        {
            Die();
            Debug.Log("Enemy Killed!");
            timeBtwDamage = Time.time + 2f;
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
