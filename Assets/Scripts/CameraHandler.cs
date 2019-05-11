using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraHandler : MonoBehaviour
{
    public GameObject cam;
    public float yDeg = 30;
    public float xDeg = 90;
    public int sensetivity = 3;
    public float r = 7f;
    public GameObject sphere;
    private Vector3[] positions = new Vector3[2];
    private bool returnMinus = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // Variables
        float xOffset = Input.GetAxis("Mouse X");
        float yOffset = Input.GetAxis("Mouse Y");
        float x = r * Mathf.Sin(DegToRadians(xDeg)) * Mathf.Cos(DegToRadians(yDeg));
        float y = r * Mathf.Sin(DegToRadians(yDeg)) * Mathf.Sin(DegToRadians(xDeg));
        float z = r * Mathf.Cos(DegToRadians(xDeg));

        // Camera Controller
        Vector3 pos = new Vector3(x, y, z) + sphere.transform.position;
        cam.transform.position = pos;
        xDeg = MinMax(30, 150, xDeg + (xOffset / sensetivity));
        yDeg = MinMax(-15, 35, yDeg - (yOffset / sensetivity));
        
        this.transform.LookAt(sphere.transform);
    }

    float MinMax(float min, float max, float value)
    {
        value = Math.Max(min, value);
        value = Math.Min(max, value);

        return value;
    }

    float DegToRadians(float deg)
    {
        return Mathf.PI * deg / 180;
    }
}
