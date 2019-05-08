using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject cam;
    public float yDeg = 30;
    public float xDeg = 90;
    public float r = 7f;
    public GameObject sphere;
    private Vector3[] positions = new Vector3[2];
    private bool returnMinus = false;

    void Update()
    {
        // Variables
        float x = r * Mathf.Sin(DegToRadians(xDeg)) * Mathf.Cos(DegToRadians(yDeg));
        float y = r * Mathf.Sin(DegToRadians(yDeg)) * Mathf.Sin(DegToRadians(xDeg));
        float z = r * Mathf.Cos(DegToRadians(xDeg));

        // Camera Controller
        cam.transform.position = new Vector3(x, y, z) + sphere.transform.position;

        this.transform.LookAt(sphere.transform);
    }

    float DegToRadians(float deg)
    {
        return Mathf.PI * deg / 180;
    }

}
