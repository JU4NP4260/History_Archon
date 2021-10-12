using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int meleeDamage)
    {
        currentHealth -= meleeDamage;

        //animacion de deano

        if (currentHealth <= 0)
        {
            DeathAnimation();

        }
    }

    void DeathAnimation()
    {
        Debug.Log("Enemy killed");
        //Death Animation

        //Destroy enemy
    }
}
