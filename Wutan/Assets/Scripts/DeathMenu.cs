using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
