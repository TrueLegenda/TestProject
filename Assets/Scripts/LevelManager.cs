using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables
    public GameObject surface;
    public static bool FinishedGenerating = false;
    private float minX = 0;
    // Instructions For GameManager
    public static List<Vector3> Position = new List<Vector3>();
    public static List<string> Model = new List<string>();

    void Start()
    {
        // Determine Amount Of Obstacles
        // Instructions For Object's Position
        Position.Add(new Vector3(-24f, 1f, -0.5f));
        Position.Add(new Vector3(-8, 3f, -0.5f));
        Position.Add(new Vector3(-16, 5f, -5f));

        // Instructions For Object's Model
        Model.Add("Floor");
        Model.Add("Obstacle");
        Model.Add("Obstacle");

        //Call GameManager
        FinishedGenerating = true;
    }

    void Update()
    {
        
    }

}
