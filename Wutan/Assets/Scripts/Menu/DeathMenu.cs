using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    
    void Update()
    {
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
