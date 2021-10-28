using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            FindObjectOfType<AudioManager>().Play("FallDeath");
            controller.ChangeHealth(-100);
        }
       
    }
}
