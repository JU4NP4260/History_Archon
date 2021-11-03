using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervisorBullet : MonoBehaviour
{
    public float dieTime, bulletSpeed = 10f;
    public int bulletDamage = 1;
    public Rigidbody2D rb;
    public GameObject player;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }
}
