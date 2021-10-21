using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 5f;

    private void Awake()
    {
        StartCoroutine(waiter());
    }

   IEnumerator waiter()
    {
        yield return new WaitForSeconds(6);
        Object.Destroy(this.gameObject);
    }
}
