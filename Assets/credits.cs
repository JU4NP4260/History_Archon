using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public float Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, Move + 0.003f, 0f);
    }
}
