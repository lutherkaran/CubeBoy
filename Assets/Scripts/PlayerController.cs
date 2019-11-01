using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float moveForce;
    public float rotationalForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RelativeMovements();
    }
    void RelativeMovements()
    {
        //Vector3 dir = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * moveForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Vector3.forward * moveForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(new Vector3(0,-rotationalForce,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(new Vector3(0, rotationalForce,0));
        }
        //dir = dir.normalized;
        //rb.velocity = dir * moveForce;
    }
}
