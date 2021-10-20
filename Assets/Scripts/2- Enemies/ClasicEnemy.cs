using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasicEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;


    public float moveSpeed;
    public int EnemyHealth = 15;


    [HideInInspector]
    public bool mustPatrol;
    public bool mustFlip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
    }

    void Patrol()
    {
        if (mustFlip)
        {
            Flip();

        }

        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-0.2f, 0.2f);
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
            player.ChangeHealth(-2);
        }
    }


    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        Debug.Log("Damage TAKEN!");
        if(EnemyHealth <= 0)
        {
            Die();
            Debug.Log("Enemy Killed!");
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}

