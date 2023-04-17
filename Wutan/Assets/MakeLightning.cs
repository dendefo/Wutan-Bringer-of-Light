using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLightning : MonoBehaviour
{
    public Camera MainCam;
    public LineRenderer LightningLine;
    public Transform FirePoint;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            EnableEffect();
        }
        if (Input.GetButton("Fire1"))
        {
            UpdateEffect();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            DisableEffect();
        }


        void EnableEffect()
        {
            LightningLine.enabled = true;
        }
        void UpdateEffect()
        {
            var mousePos = (Vector2)MainCam.ScreenToWorldPoint(Input.mousePosition);

            LightningLine.SetPosition(0, FirePoint.position);

            LightningLine.SetPosition(1, mousePos);

        }
        void DisableEffect()
        {
            LightningLine.enabled = false;
        }
    }
}
