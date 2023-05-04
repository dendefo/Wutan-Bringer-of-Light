using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public List<Spawner> spawners;
    public PlayerScript PlayerScriptplayer;
    public List<Enemy> Enemies;
    public float MinDistanceFromPlayerToSpawn;
    public AnimationCurve Curve;


    void Awake()
    {
        Instance = this;
        spawners = new List<Spawner>();
    }
    private void Update()
    {
       
    }
}
