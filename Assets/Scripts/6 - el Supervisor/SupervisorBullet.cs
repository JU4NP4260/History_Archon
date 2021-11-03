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

    private void OnCollisionEnter2D(Collision2D other)
    {

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
        Destroy(gameObject);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
