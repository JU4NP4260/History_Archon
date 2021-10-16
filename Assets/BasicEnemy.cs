using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;

    public int EnemyHealth = 15;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-0.2f, 0.2f);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;

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
