using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20f;
    public int bulletDamage = 2;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Basic_Enemy enemy = hitInfo.GetComponent<Basic_Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDamage);

        }
        Destroy(gameObject);
    }
}
