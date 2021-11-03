using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElSupervisor : MonoBehaviour
{
    [Header("BoxCollider")]
    public CapsuleCollider2D Collider;

    [Header("Projectiles")]
    public Transform shootPos1;
    public Transform shootPos2;
    public Transform shootPos3;
    public Transform shootPos4;
    public GameObject Projectile;


    [Header("Boss Health")]
    public int CurrentBossHealth;
    public int bossHealth = 70;


    private float rotationCycle;
    private float rotation;
    private float timeBtwShot;

    void Start()
    {
        rotationCycle = 1f;
        CurrentBossHealth = bossHealth;
    }
    void Update()
    {
        if (timeBtwShot <= Time.time)
        {
            Shoot();
            timeBtwShot = Time.time + .5f;
        }
        else
        {
            timeBtwShot -= Time.deltaTime; 
        }
        rotation = (rotationCycle + Time.time)/2;
        transform.Rotate(0f, 0f, rotation);
    }
    void Shoot()
    {
        Instantiate(Projectile, shootPos1.position, shootPos1.rotation);
        Instantiate(Projectile, shootPos2.position, shootPos2.rotation);
        Instantiate(Projectile, shootPos3.position, shootPos3.rotation);
        Instantiate(Projectile, shootPos4.position, shootPos4.rotation);
    }

    public void TakeDamage(int damage)
    {
        CurrentBossHealth -= damage;
        Debug.Log("Damage TAKEN!");
        FindObjectOfType<AudioManager>().Play("EnemyHurt");

        if (CurrentBossHealth <= 0)
        {
            Die();
            Debug.Log("BOSS Killed!");
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    /*
    void sisas()
    {
        StartCoroutine(StartShoot());
    }
    IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2f);
            Shoot();
        }
    }
    */
}
