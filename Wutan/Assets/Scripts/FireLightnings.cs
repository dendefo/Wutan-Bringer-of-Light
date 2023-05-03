using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightnings : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRender;
    public Transform pointOfWand;

    private Quaternion rotation;
    void Start()
    {
        DisableLightnings();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EnableLightning();
        }
        if (Input.GetButton("Fire1"))
        {
            UpdateLightning();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            DisableLightnings();
        }
        RotateToMouse();
    }
    void EnableLightning()
    {
        lineRender.enabled = true;
    }
    void UpdateLightning()
    {
        var mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
        lineRender.SetPosition(0, pointOfWand.position);
        lineRender.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);

        if(hit)
        {
            lineRender.SetPosition(1, hit.point);
        }
    }
    void DisableLightnings()
    {
        lineRender.enabled = false;
    }
    void RotateToMouse()
    {
        Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;
    }
}
