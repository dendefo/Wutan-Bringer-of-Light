using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float SpawnRate;
    [SerializeField] List<Enemy> EnemyPrefabs;
    private float LastSpawnTime = 0;

    void Start()
    {
        GameManager.Instance.spawners.Add(this);
    }


    void Update()
    {
        if (Time.timeSinceLevelLoad > LastSpawnTime + SpawnRate)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.PlayerScriptplayer.transform.position) > GameManager.Instance.MinDistanceFromPlayerToSpawn)
            {
                if (GameManager.Instance.Curve.Evaluate(Time.timeSinceLevelLoad) <= GameManager.Instance.Enemies.Count) return;
                Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)],transform.position,Quaternion.identity,null);
                LastSpawnTime = Time.timeSinceLevelLoad;
            }
        }
    }
}
