using System;
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
        Time.fixedDeltaTime = Time.deltaTime;
        v = 1f;
        vCap = 1.5f;
        thrust = 0.23f;
    }
    void Update()
    {
        // Check if key is pressed
        if (Input.anyKey)
        {
            // Variables
            KeyCode key = GetKey();
            Vector3 ForceDirection = Vector3.zero;

            // Check key
            if (key == KeyCode.W)
            {
                ForceDirection = new Vector3(-thrust * v, 0f, 0f);
            }
            else if (key == KeyCode.S)
            {
                ForceDirection = new Vector3(thrust * v, 0f, 0f);
            }
            else if (key == KeyCode.D)
            {
                ForceDirection = new Vector3(0f, 0f, thrust * v);
            }
            else if (key == KeyCode.A)
            {
                ForceDirection = new Vector3(0f, 0f, -thrust * v);
            }
            else if (key == KeyCode.Space && collisionDetected)
            {
                ForceDirection = new Vector3(0f, 2f, 0f);
            }

            // Add force
            rb.AddForce(ForceDirection, ForceMode.Impulse);
            
            // Refresh velocity
            if (v <= vCap)
            {
                v += 0.05f;
            }
        }
        else
        {
            // Reset velocity
            v = 1;
        }
    }

    KeyCode GetKey()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
            {
                return key;
            }
        }

        return KeyCode.None;
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