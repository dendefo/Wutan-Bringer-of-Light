using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicMenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Abilities ability;
    public Image image;
    static public MagicMenuButtons chosen;
    public GameObject prefab;
    private Sprite Basic;
    public Sprite Highlight;

    private void Awake()
    {
        Basic = image.sprite;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        chosen = this;
        image.sprite = Highlight;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = Basic;
    }
    private void Update()
    {
        if (Input.GetAxis("ChoseSpell") == 0) return;

        var angle = GameManager.Instance.PlayerScriptplayer.StickAngle;
        switch (ability)
        {
            case Abilities.Fire:
                if (angle > 315 || angle <= 45)
                {
                    OnPointerEnter(null);
                }
                else OnPointerExit(null);
                break;
            case Abilities.Thunder:
                //if (angle > 45 && angle <= 135)
                {
                //    OnPointerEnter(null);
                }
                //else OnPointerExit(null);
                break;
            case Abilities.Air:
                if (angle > 135 && angle <= 225)
                {
                    OnPointerEnter(null);
                }
                else OnPointerExit(null);
                break;
            case Abilities.Light:
                if (angle > 225 && angle <= 315)
                {
                    OnPointerEnter(null);
                }
                else OnPointerExit(null);
                break;
            default: break;
        }
    }
}
public enum Abilities
{
    Fire,
    Air,
    Light,
    Thunder
}