using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
