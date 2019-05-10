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

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    void Update()
    {
        print(cam);
        // Variables
        positions[0] = positions[1];
        positions[1] = Input.mousePosition;
        float xOffset = positions[1].x - positions[0].x;
        float yOffset = positions[1].y - positions[0].y;
        float x = r * Mathf.Sin(DegToRadians(xDeg)) * Mathf.Cos(DegToRadians(yDeg));
        float y = r * Mathf.Sin(DegToRadians(yDeg)) * Mathf.Sin(DegToRadians(xDeg));
        float z = r * Mathf.Cos(DegToRadians(xDeg));

        // Camera Controller
        cam.transform.position = new Vector3(x, y, z) + sphere.transform.position;
        xDeg += xOffset / 10;
        yDeg -= yOffset / 10;

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            print(Input.mousePosition);
        }

        this.transform.LookAt(sphere.transform);

        // Zoom
        print(Input.mouseScrollDelta);
    }

    float DegToRadians(float deg)
    {
        return Mathf.PI * deg / 180;
    }
}
