using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MagicMenu : MonoBehaviour
{
    public Canvas menu; // Assign in inspector
    private bool isShowing;
    public GameObject Parent;
    public float LastClick;
    public float delay = 0.1f;
    [SerializeField] Transform Staff;
    [SerializeField] public float CDForFire;
    [SerializeField] public float CDForThunder;
    [SerializeField] public float CDForLight;
    [SerializeField] public float CDForAir;
    [SerializeField] public float LastUseForFire = 0;
    [SerializeField] public float LastUseForThunder = 0;
    [SerializeField] public float LastUseForLight = 0;
    [SerializeField] public float LastUseForAir = 0;

    public static MagicMenu instance;

    private void Start()
    {
        menu.enabled = false;
        instance= this;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            LastClick = Time.timeSinceLevelLoad;

        }
        else if (Input.GetMouseButton(1))
        {
            if (Time.timeSinceLevelLoad < LastClick + delay) return;

            menu.enabled = isShowing;
            if (!isShowing)
            {
                Vector2 mousePos = Input.mousePosition;
                Parent.transform.position = mousePos;
                Time.timeScale = 0.1f;
            }
            isShowing = true;
        }
        else if (Input.GetMouseButtonUp(1)||Input.GetAxis("Spell")!=0)
        {
            if (MagicMenuButtons.chosen != null&& !isShowing)
            {
                switch (MagicMenuButtons.chosen.ability)
                {
                    case Abilities.Fire:
                        if (Time.timeSinceLevelLoad - LastUseForFire <= CDForFire)
                            return;
                        LastUseForFire = Time.timeSinceLevelLoad;
                        break;
                    case Abilities.Air:
                        if (Time.timeSinceLevelLoad - LastUseForAir <= CDForAir)
                            return;
                        LastUseForAir = Time.timeSinceLevelLoad;
                        break;
                    case Abilities.Light:
                        if (Time.timeSinceLevelLoad - LastUseForLight <= CDForLight)
                            return;
                        LastUseForLight = Time.timeSinceLevelLoad;
                        break;
                    case Abilities.Thunder:
                        if (Time.timeSinceLevelLoad - LastUseForThunder <= CDForThunder)
                            return;
                        LastUseForThunder = Time.timeSinceLevelLoad;
                        break;
                }
                if (MagicMenuButtons.chosen.ability == Abilities.Light)
                {
                    GameManager.Instance.PlayerScriptplayer.animator.SetTrigger("Light");
                }
                else
                {
                    GameManager.Instance.PlayerScriptplayer.animator.SetTrigger("Spell");
                }
                Instantiate(MagicMenuButtons.chosen.prefab, Staff.position+ MagicMenuButtons.chosen.prefab.transform.position, MagicMenuButtons.chosen.prefab.transform.rotation, null);
            }
            isShowing = false;
            menu.enabled = isShowing;

            Time.timeScale = 1;

        }
        if (Gamepad.current == null) return;
        if (Input.GetAxis("ChoseSpell") != 0)
        {
            menu.enabled = isShowing;
            if (!isShowing)
            {
                //Vector2 mousePos = new Vector2(Input.GetAxis("Joystick Horizontal"),Input.GetAxis("Joystick Vertical"));
                //Parent.transform.position = mousePos;
                Time.timeScale = 0.1f;
            }
            isShowing = true;
        }
        else if (Input.GetAxis("ChoseSpell") == 0)
        {


            isShowing = false;
            menu.enabled = isShowing;

            Time.timeScale = 1;
        }

    }
}
