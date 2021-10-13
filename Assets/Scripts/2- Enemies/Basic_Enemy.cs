using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{
    public int maxHealth = 15;
    int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int meleeDamage)
    {
        currentHealth -= meleeDamage;
        Debug.Log("Damage TAKEN!");
        //animacion de deano

        if (currentHealth <= 0)
        {
            DeathAnimation();

        }
    }


    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void DeathAnimation()
    {
        Debug.Log("Enemy killed");
        //Death Animation

        //Destroy enemy
    }
}
