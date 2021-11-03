using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCombat : MonoBehaviour
{
    /*
    [Header("Enemies")]
    [SerializeField] BasicEnemy enemy_1;
    [SerializeField] ClasicEnemy enemy_2;
    [SerializeField] ClasicEnemyRange enemy_3;
    [SerializeField] VictorianEnemyRange enemy_4;
    */

    [Header("Melee Config.")]
    public Transform meleePos;
    public LayerMask enemyLayers;
    public Animator anim;

    private float timeBtwAttack;
    public float StartTimeBtwAttack;

    public float meleeRange = 0.6f;
    public int meleeDamage = 1;

    [Header("Range Attack Config.")]
    public Transform firePoint;
    public GameObject Projectile_01;

    private bool m_FacingRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timeBtwAttack <= Time.time)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                MeleeAttack();
                timeBtwAttack = Time.time + 0.5f;
                anim.Play("Timoff_Meleeanim");
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeBtwAttack = Time.time + 0.5f;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void MeleeAttack()
    {
        //Mostrar animacion
        //Animator.SetTrigger("MeleeAtack");

        //Detectar los enemigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePos.position, meleeRange, enemyLayers);

        //Sonido
        FindObjectOfType<AudioManager>().Play("MeleeAtack");

        //Hacer dano

        /*
        for (int i = 0; i< hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<VictorianEnemyRange>().TakeDamage(meleeDamage);
            hitEnemies[i].GetComponent<BasicEnemy>().TakeDamage(meleeDamage);
            hitEnemies[i].GetComponent<ClasicEnemy>().TakeDamage(meleeDamage);
            hitEnemies[i].GetComponent<ClasicEnemyRange>().TakeDamage(meleeDamage);
        }

        */
    }


    void Shoot()
    {
        Instantiate(Projectile_01, firePoint.position, firePoint.rotation);

    }

    IEnumerator enemy1Damage(BasicEnemy enemy)
    {        
        enemy.TakeDamage(meleeDamage);

        yield return new WaitForSeconds(0.6f);       

    }

    IEnumerator enemy2Damage(ClasicEnemy enemy)
    {
        enemy.TakeDamage(meleeDamage);

        yield return new WaitForSeconds(0.6f);

    }

    IEnumerator enemy3Damage(ClasicEnemyRange enemy)
    {
        enemy.TakeDamage(meleeDamage);

        yield return new WaitForSeconds(0.6f);

    }

    IEnumerator enemy4Damage(VictorianEnemyRange enemy)
    {
        enemy.TakeDamage(meleeDamage);

        yield return new WaitForSeconds(0.6f);

    }

    IEnumerator enemy5Damage(ElSupervisor enemy)
    {
        enemy.TakeDamage(meleeDamage);

        yield return new WaitForSeconds(0.6f);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        BasicEnemy basicEnemy = collision.GetComponent<BasicEnemy>();
        ClasicEnemy classicEnemy = collision.GetComponent<ClasicEnemy>();
        ClasicEnemyRange classicEnemyRange = collision.GetComponent<ClasicEnemyRange>();
        VictorianEnemyRange victorianEnemyRange = collision.GetComponent<VictorianEnemyRange>();

        if (basicEnemy != null)
        {
            if (Input.GetKey(KeyCode.K))
            {
                StartCoroutine(enemy1Damage(basicEnemy));
            }
        }

        if (classicEnemy != null)
        {
            if (Input.GetKey(KeyCode.K))
            {
                StartCoroutine(enemy2Damage(classicEnemy));
            }
        }

        if (classicEnemyRange != null)
        {
            if (Input.GetKey(KeyCode.K))
            {
                StartCoroutine(enemy3Damage(classicEnemyRange));
            }
        }

        if (victorianEnemyRange != null)
        {
            if (Input.GetKey(KeyCode.K))
            {
                StartCoroutine(enemy4Damage(victorianEnemyRange));
            }
        }
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
