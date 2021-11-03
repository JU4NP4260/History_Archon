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

        ClasicEnemyRange enemy2 = hitInfo.GetComponent<ClasicEnemyRange>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(bulletDamage);

        }
        Destroy();

        ClasicEnemy enemy3 = hitInfo.GetComponent<ClasicEnemy>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(bulletDamage);
        }

        Destroy();VictorianEnemyRange enemy4 = hitInfo.GetComponent<VictorianEnemyRange>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(bulletDamage);

        }
        Destroy();

        Destroy(); ElSupervisor enemy5 = hitInfo.GetComponent<ElSupervisor>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(bulletDamage);
        }
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);

    }
}
