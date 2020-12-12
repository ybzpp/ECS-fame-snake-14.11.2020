using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rgScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Speed, ForceMode.Impulse);
        }
    }
}
