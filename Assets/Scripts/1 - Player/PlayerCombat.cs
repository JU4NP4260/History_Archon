using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Melee Config.")]
    public Transform meleePos;
    public LayerMask enemyLayers;

    private float timeBtwAttack;
    public float StartTimeBtwAttack;

    public float meleeRange = 0.6f;
    public int meleeDamage = 5;

    [Header("Range Attack Config.")]
    public Transform firePoint;
    public GameObject Projectile_01;

    private bool m_FacingRight = true;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                MeleeAttack();
                timeBtwAttack = StartTimeBtwAttack;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    void MeleeAttack()
    {
        //Mostrar animacion
        //Animator.SetTrigger("MeleeAtack");

        //Detectar los enemigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePos.position, meleeRange, enemyLayers);

        //Hacer dano
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<BasicEnemy>().TakeDamage(meleeDamage);
        }

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<ClasicEnemy>().TakeDamage(meleeDamage);
        }


    }

    void Shoot()
    {
        Instantiate(Projectile_01, firePoint.position, firePoint.rotation);

    }

    private void OnDrawGizmosSelected()
    {
        if (meleePos == null)
            return;

        Gizmos.DrawWireSphere(meleePos.position, meleeRange);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);

    }
}
