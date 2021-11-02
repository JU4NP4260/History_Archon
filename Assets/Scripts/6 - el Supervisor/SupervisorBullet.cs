using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervisorBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public int bulletDamage = 1;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(bulletDamage);

        }
        Destroy();

    }

    private void Destroy()
    {
        Destroy(gameObject);

    }
}
