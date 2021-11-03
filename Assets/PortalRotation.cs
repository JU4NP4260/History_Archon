using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotation : MonoBehaviour
{
    public float rotationCycle;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotation + 0.2f);
    }
}
