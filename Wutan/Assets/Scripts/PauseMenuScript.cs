using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.DieMenu.active && !MagicMenu.instance.menu.enabled)
        {
            if (!PauseMenu.active)
            {
                PauseMenu.SetActive(true);
                GameManager.Instance.HUD.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                Unpause();
            }
            
        }
    }
    public void Unpause()
    {
        PauseMenu.SetActive(false);
        GameManager.Instance.HUD.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void Load()
    {
        SceneManager.LoadScene(0);
    }
}
