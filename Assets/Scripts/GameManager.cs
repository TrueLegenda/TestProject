﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    System.Random rnd = new System.Random();
    //Variables
    public static int Level = 1;
    //Save Specific GameObjects From Inspector
    public GameObject Floor;
    public GameObject Obstacle_1;
    public GameObject Obstacle_2;
    public GameObject Endpoint;

    void Update()
    {
        if(LevelManager.FinishedGenerating)
        {
            for (int i = 0; i < LevelManager.Position.Count; i++)
            {
                GameObject obj = Floor;
                switch (LevelManager.Model[i])
                {
                    case "Floor":
                        obj = Floor;
                        break;
                    case "Obstacle":
                        obj = Obstacle_2;
                        break;
                }

                Instantiate(obj, LevelManager.Position[i], new Quaternion());
            }
            LevelManager.FinishedGenerating = false;
        }
    }
}
