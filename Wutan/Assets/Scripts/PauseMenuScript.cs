using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                PauseMenu.SetActive(false);
                GameManager.Instance.HUD.SetActive(true);
                Time.timeScale = 1.0f;
            }
            
        }
    }
}
