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

        BasicEnemy enemy = hitInfo.GetComponent<BasicEnemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDamage);

        }
        Destroy();

        ClasicEnemy enemy2 = hitInfo.GetComponent<ClasicEnemy>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(bulletDamage);

        }
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);

    }
}
