using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();


        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                if(controller.currentHealth != 0)
                {
                    FindObjectOfType<AudioManager>().Play("Health");
                }
                Destroy(gameObject);    
                controller.ChangeHealth(+1);
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
