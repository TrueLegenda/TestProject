using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    System.Random rnd = new System.Random();
    // Variables
    private GameObject player;
    public GameObject surface;
    public static bool FinishedGenerating = false;
    // Instructions For GameManager
    public static List<Vector3> Position = new List<Vector3>();
    public static List<string> Model = new List<string>();

    void Start()
    {
        // Assign Variable Values
        player = GameObject.Find("Player");
        // Generate The Initial Map
        GenerateMap();
    }

    void Update()
    {
        if(GameManager.IsLevelFinished)
        {
            // Clear Insructions Data
            Position.RemoveAll(item => item != null);
            Model.RemoveAll(item => item != null);

            // Reset Level Variables
            GameManager.IsLevelFinished = false;
            GameManager.Level++;

            // Remove Current Map
            GameManager.ClearMap();

            // Generate Next Map
            GenerateMap();

            // Respawn
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Respawn
        player.transform.position = new Vector3(0, 3.7f, 0);
        // Reset Momentom
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void GenerateMap()
    {
        //Add Floor Data
        Position.Add(new Vector3(-48f, 1f, -0.5f));
        Model.Add("Floor");

        // Determine Amount Of Obstacles
        // Whole Surface Size
        float surfaceX = surface.transform.localScale.x;
        // Room For Obstacles After Subtracting Spawn And Finish Area
        int room = Convert.ToInt32(surfaceX - surfaceX / 6);
        // Amount Of Obstacles - Spacing Of At Least 2 And Maximum Of 4 Between Obstacles
        int obstaclesAmount = rnd.Next(room / 8, room / 4);
        // Spacing
        int spacing = room / obstaclesAmount;

        // Instructions For Object's Properties (Model And Position)
        for (int i = 0; i < obstaclesAmount; i++)
        {
            Vector3 pos = new Vector3(-2 - spacing * (i + 1), i * rnd.Next(2, 3), rnd.Next(-6, 6));
            Position.Add(pos);
            Model.Add("Obstacle");
        }

        // Create Instructions For Endpoint
        Position.Add(new Vector3(Position[obstaclesAmount][0] - 3.8f, Position[obstaclesAmount][1], -0.5f));
        Model.Add("Endpoint");

        //Call GameManager
        FinishedGenerating = true;
    }

}
