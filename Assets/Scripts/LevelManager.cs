using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    // Create A Random() Instance
    System.Random rnd = new System.Random();
    // Variables
    private GameObject player;
    public GameObject surface;
    public static bool FinishedGenerating = false;
    // Instructions For GameManager
    public static List<Vector3> Positions = new List<Vector3>();
    public static List<ObjectType> Models = new List<ObjectType>();
    private Vector3 initScale;

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
            Positions.Clear();
            Models.Clear();

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
        // Set Level Difficulty
        surface.transform.localScale += new Vector3(0.25f * 50f, 0f, 0f);

        // Add Floor Data
        Positions.Add(new Vector3(-surface.transform.localScale.x / 2 + 3, 1f, -0.5f));
        Models.Add(ObjectType.Floor);

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
            Vector3 pos = new Vector3(-spacing * (i + 1), (i + 1) * rnd.Next(2, 3), rnd.Next(-6, 6));
            Positions.Add(pos);
            Models.Add(ObjectType.Obstacle);
        }

        // Create Instructions For Endpoint
        Positions.Add(new Vector3(Positions[obstaclesAmount][0] - 3.8f, Positions[obstaclesAmount][1], -0.5f));
        Models.Add(ObjectType.Endpoint);

        //Call GameManager
        FinishedGenerating = true;
    }

    private void OnApplicationQuit()
    {
        // Reset Floor Size When Player Quits
        ResetFloor();
    }

    void ResetFloor()
    {
        surface.transform.localScale = new Vector3(50f, 1, 16);
    }
}
