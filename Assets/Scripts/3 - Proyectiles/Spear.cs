using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePEFFECt;
    public GameObject Player;

    void Start()
    {
        StartCoroutine(CountDownTime());
    }

    void Update()
    {
        
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

    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }

    /*
    public void OnTriggerEnter2D()
    {
        PlayerController.ChangeHealth

    }

    */
}
