using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesQueDesaparecen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

    void Destroy()
    {

        Destroy(gameObject, 2.0f);

    }
}
