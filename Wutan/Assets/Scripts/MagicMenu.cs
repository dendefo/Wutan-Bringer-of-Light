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
    public float LastClick;
    public float delay = 0.1f;
    [SerializeField] Transform Staff;
    private void Start()
    {
        menu.enabled = false;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            LastClick = Time.time;

        }
        else if (Input.GetMouseButton(1))
        {
            if (Time.time < LastClick + delay) return;

            menu.enabled = isShowing;
            if (!isShowing)
            {
                Vector2 mousePos = Input.mousePosition;
                Parent.transform.position = mousePos;
            }
            isShowing = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (MagicMenuButtons.chosen != null&& !isShowing)
            {
                Instantiate(MagicMenuButtons.chosen.prefab, Staff.position+ MagicMenuButtons.chosen.prefab.transform.position, MagicMenuButtons.chosen.prefab.transform.rotation, null);

            }
            isShowing = false;
            menu.enabled = isShowing;
            

        }
        
    }
}
