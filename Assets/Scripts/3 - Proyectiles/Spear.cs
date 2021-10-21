using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePEFFECt;

    void Start()
    {
        StartCoroutine(CountDownTime());
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }

    void Flip() { 
    }
}
