using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasicEnemyRange : MonoBehaviour
{   
    [Header("Must Reference")]
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, ShootPos;
    public GameObject Spear;
    public Animator animator;

    [Header("Variables")]
    public float moveSpeed;
    public float shootRange;
    public float timeBTWShots;
    public float spearSpeed;
    public int EnemyHealth = 15;
    private float distToPlayer;


    [HideInInspector]
    public bool mustPatrol;
    public bool mustFlip, canShoot;
    private int CurrentEnemyHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mustPatrol = true;
        canShoot = true;
        CurrentEnemyHealth = EnemyHealth;
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

        if(distToPlayer <= shootRange)
        {
            animator.Play("Classc_Shooting");
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            if(canShoot == true)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            mustPatrol = true;
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        GameObject newSpear = Instantiate(Spear, ShootPos.position, Quaternion.identity);

        newSpear.GetComponent<Rigidbody2D>().velocity = new Vector2(spearSpeed * moveSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;

    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
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
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }


    public void TakeDamage(int damage)
    {
        CurrentEnemyHealth -= damage;
        Debug.Log("Damage TAKEN!");
        FindObjectOfType<AudioManager>().Play("EnemyHurt");

        if (CurrentEnemyHealth <= 0)
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

