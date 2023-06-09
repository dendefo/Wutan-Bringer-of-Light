using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float SpawnRate;
    [SerializeField] Enemy EnemyPrefab;
    private float LastSpawnTime = 0;

    void Start()
    {
        GameManager.Instance.spawners.Add(this);
    }


    void Update()
    {
        if (Time.time > LastSpawnTime + SpawnRate)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.PlayerScriptplayer.transform.position) > GameManager.Instance.MinDistanceFromPlayerToSpawn)
            {
                if (GameManager.Instance.Curve.Evaluate(Time.time) <= GameManager.Instance.Enemies.Count) return;
                Instantiate(EnemyPrefab,transform.position,Quaternion.identity,null);
                LastSpawnTime = Time.time;
            }
        }
    }
}
