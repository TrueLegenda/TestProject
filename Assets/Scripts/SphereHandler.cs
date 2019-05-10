using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    // Variables
    public static bool FinishedLevel = false;
    public static int Health = 3;
    private bool collisionDetected = true;
    public GameObject sphere;
    public Rigidbody rb;
    public float v;
    public float vCap;
    public float thrust;

    bool IsOutOfBoundaries()
    {
        return sphere.transform.position.y < -1;
    }

    private void Respawn()
    {
        // Respawn
        sphere.transform.position = new Vector3(0, 3.7f, 0);

        // Reset Momentom
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Start()
    {
        v = 1f;
        vCap = 1.5f;
        thrust = 0.23f;
    }
    void Update()
    {
        // Respawn Player
        if (IsOutOfBoundaries())
        {
            Respawn();
            Health--;
        }

        // Check If Player Dies
        if(Health <= 0)
        {
            Application.Quit();
        }

        // Check if key is pressed
        if (Input.anyKey)
        {
            // Variables
            KeyCode key = GetKey();
            Vector3 ForceDirection = Vector3.zero;

            // Check key
            if (key == KeyCode.W)
            {
                Move("forward");
            }
            else if (key == KeyCode.S)
            {
                Move("backward");
            }
            else if (key == KeyCode.D)
            {
                Move("right");
            }
            else if (key == KeyCode.A)
            {
                Move("left");
            }
            else if (key == KeyCode.Space/* && collisionDetected*/)
            {
                Move("up");
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

    void Move(string dir)
    {
        Vector3 forceDirection = new Vector3();

        switch(dir)
        {
            case "forward":
                forceDirection = new Vector3(-thrust, 0f, 0f);
                break;
            case "backward":
                forceDirection = new Vector3(thrust, 0f, 0f);
                break;
            case "right":
                forceDirection = new Vector3(0f, 0f, thrust);
                break;
            case "left":
                forceDirection = new Vector3(0f, 0f, -thrust);
                break;
            case "up":
                forceDirection = new Vector3(0f, 2f, 0f);
                break;
        }
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        collisionDetected = true;

        // Check If Player Finished The Level
        if (other.collider.tag == "Endpoint")
        {
            // Next Level
            GameManager.IsLevelFinished = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collisionDetected = false;
    }
}