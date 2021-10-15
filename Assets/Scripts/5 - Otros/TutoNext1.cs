using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoNext1 : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject PlayerObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObject.transform.position = teleportTarget.transform.position; 
        }
    }
}
