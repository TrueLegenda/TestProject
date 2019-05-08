using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create A Random() Instance
    System.Random rnd = new System.Random();
    //Variables
    public static int Level = 1;
    public static bool IsLevelFinished = false;
    //Save Specific GameObjects From Inspector
    public GameObject Floor;
    public GameObject Obstacle_1;
    public GameObject Obstacle_2;
    public GameObject Endpoint;

    void Update()
    {
        // Check If Player Wants To Quit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(LevelManager.FinishedGenerating)
        {
            for (int i = 0; i < LevelManager.Positions.Count; i++)
            {
                GameObject obj = Floor;
                switch (LevelManager.Models[i])
                {
                    case ObjectType.Floor:
                        obj = Floor;
                        obj.name = "Floor";
                        break;
                    case ObjectType.Obstacle:
                        // Choose Obstacle Randomly
                        if (rnd.Next(1, 5) == 1)
                        {
                            obj = Obstacle_1;
                            obj.name = "Obstacle_1";

                            // Set Z Position To The Middle Of The Map
                            LevelManager.Positions[i] = new Vector3(LevelManager.Positions[i].x, LevelManager.Positions[i].y, -0.5f);
                        }
                        else
                        {
                            obj = Obstacle_2;
                            obj.name = "Obstacle_2";
                        }
                        break;
                    case ObjectType.Endpoint:
                        obj = Endpoint;
                        obj.name = "Endpoint";
                        break;
                }
                Instantiate(obj, LevelManager.Positions[i], new Quaternion());
            }
            LevelManager.FinishedGenerating = false;
        }
    }

    public static void ClearMap()
    {
        Destroy(GameObject.FindGameObjectWithTag("FloorTag"));
        Destroy(GameObject.FindGameObjectWithTag("Endpoint"));
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Obstacle").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Obstacle")[i]);
        }
    }

}

public enum ObjectType
{
    None,
    Obstacle,
    Floor,
    Endpoint
}