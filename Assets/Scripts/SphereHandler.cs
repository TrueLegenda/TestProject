using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private bool collisionDetected = true;
    public GameObject sphere;
    public Rigidbody rb;
    public float v;
    public float vCap;
    public float thrust;

    void Start()
    {
        v = 1f;
        vCap = 1.5f;
        thrust = 0.23f;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(-thrust * v, 0f, 0f, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(thrust * v, 0f, 0f, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(0f, 0f, thrust * v, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(0f, 0f, -thrust * v, ForceMode.VelocityChange);
            }

            if(Input.GetKey(KeyCode.Space) && collisionDetected)
            {
                rb.AddForce(0f, 2f, 0f, ForceMode.Impulse);
            }

            if (v <= vCap)
            {
                v += 0.05f;
            }

        }
        else
        {
            v = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionDetected = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionDetected = false;
    }

}