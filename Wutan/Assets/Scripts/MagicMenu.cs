using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
public class MagicMenu : MonoBehaviour
{
    public Canvas menu; // Assign in inspector
    private bool isShowing;
    public GameObject Parent;
    private void Start()
    {
        menu.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            isShowing = true;
            menu.enabled = isShowing;
            Vector2 mousePos = Input.mousePosition;
            Parent.transform.position = mousePos;
            if (MagicMenuButtons.chosen != null)
            {
                Debug.Log(MagicMenuButtons.chosen.ability.ToString());

            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isShowing = false;
            menu.enabled = isShowing;
        }
        



    }
}
