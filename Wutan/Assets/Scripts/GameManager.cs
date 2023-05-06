using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public List<Spawner> spawners;
    public PlayerScript PlayerScriptplayer;
    public List<Enemy> Enemies;
    public float MinDistanceFromPlayerToSpawn;
    public AnimationCurve Curve;

    public GameObject DieMenu;
    public GameObject HUD;
    public AudioMixer SFXMixer;

    void Awake()
    {
        Instance = this;
        spawners = new List<Spawner>();
    }
    public void Die()
    {
        Time.timeScale= 0f;
        HUD.SetActive(false);
        DieMenu.SetActive(true);
        Destroy(PlayerScriptplayer.gameObject);
        //SFXMixer.SetFloat(SFXMixer.)

    }
}
