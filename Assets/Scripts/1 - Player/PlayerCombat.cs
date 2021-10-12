using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform meleePos;
    public LayerMask enemyLayers;

    public float meleeRange = 0.6f;
    public int meleeDamage = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        //Mostrar animacion
        //Animator.SetTrigger("MeleeAtack");

        //Detectar los enemigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePos.position, meleeRange, enemyLayers);

        //Hacer dano
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Basic_Enemy>().TakeDamage(meleeDamage);
        } 

    }

    private void OnDrawGizmosSelected()
    {
        if (meleePos == null)
            return;

        Gizmos.DrawWireSphere(meleePos.position, meleeRange);
    }
}
