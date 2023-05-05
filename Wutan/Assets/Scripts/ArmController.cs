using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Transform target;
    public float angleRange = 90f; // The range of angles the arm can rotate in

    void LateUpdate()
    {
        // Get the position of the mouse in screen space
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);

        // Calculate the angle between the arm and the mouse position
        Vector3 armPos = transform.position;
        Vector3 targetPos = new Vector3(mousePosWorld.x, mousePosWorld.y, armPos.z);
        float angle = Mathf.Atan2(targetPos.y - armPos.y, targetPos.x - armPos.x) * Mathf.Rad2Deg;

        // Check if the angle is within the range of 0-90 or 270-360 degrees
        if (angle >= -90 && angle <= 90f)
        {
            //Invert the rotation of the arm to face the opposite direction
            float clampedAngle = Mathf.Clamp(angle, -angleRange, angleRange);
            transform.rotation = Quaternion.Euler(0f, 0f, clampedAngle);
            GameManager.Instance.PlayerScriptplayer.IsLookingRight = true;
        }
        else
        {
            // Rotate the arm towards the target position within the range of angles
            transform.rotation = Quaternion.Euler(90, -90, -angle);                   
            GameManager.Instance.PlayerScriptplayer.IsLookingRight = false;
        }
        Debug.Log(angle);
    }
}