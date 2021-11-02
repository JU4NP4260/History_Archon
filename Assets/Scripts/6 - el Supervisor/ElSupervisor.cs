using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElSupervisor : MonoBehaviour
{
    public Transform shootPos1;
    public Transform shootPos2;
    public Transform shootPos3;
    public Transform shootPos4;
    public GameObject Projectile;

    private float rotationCycle;
    private float rotation;

    void Start()
    {
        rotationCycle = 1f;
    }

    void Shoot()
    {
        Instantiate(Projectile, shootPos1.position, shootPos1.rotation);
        Instantiate(Projectile, shootPos2.position, shootPos2.rotation);
        Instantiate(Projectile, shootPos3.position, shootPos3.rotation);
        Instantiate(Projectile, shootPos4.position, shootPos4.rotation);
    }

    IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(2f);
        Shoot();

    }

    void Update()
    {
        rotation = rotationCycle + Time.time;
        transform.Rotate(0f, 0f, rotationCycle);
        StartCoroutine(StartShoot());

    }
}
