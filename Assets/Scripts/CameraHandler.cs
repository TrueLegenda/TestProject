﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public new GameObject camera;
    public GameObject sphere;

    void Update()
    {
        Vector3 pos = sphere.transform.position;
        Vector3 newPos = new Vector3(pos[0] + 7, pos[1] + 4, pos[2]);
        camera.transform.position = newPos;
    }
}
