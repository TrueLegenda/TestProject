using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandler : MonoBehaviour
{
    public GameObject FloorModel;
    private GameObject floor;
    public GameObject Sphere;
    float floorLength;

    void Start()
    {
        floor = this.gameObject;
        FloorModel = GameObject.Find("Models/Floor");
    }

    void Update()
    {

    }
}