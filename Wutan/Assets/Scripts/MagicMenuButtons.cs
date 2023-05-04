using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicMenuButtons : MonoBehaviour,IPointerEnterHandler
{
    public Abilities ability;
    static public MagicMenuButtons chosen;

    public void OnPointerEnter(PointerEventData eventData)
    {

        chosen = this;
    }
}
public enum Abilities
{
    Fire,
    Air,
    Light,
    Thunder
}