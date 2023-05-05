using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
public class ArmController : MonoBehaviour
{
    public static ArmController Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeRotation()
    {
        // Get the position of the mouse in screen space
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);

        // Calculate the angle between the arm and the mouse position
        Vector3 armPos = transform.position;
        Vector3 targetPos = new Vector3(mousePosWorld.x, mousePosWorld.y, armPos.z);

        // Check if the angle is within the range of 0-90 or 270-360 degrees
        var norm = Vector3.Normalize(armPos - targetPos);
        var Acos = Mathf.Acos(norm.y);
        var z = Acos / Mathf.PI * 180;
        transform.localEulerAngles = new Vector3(0, 0, z-90);
        if (mousePosScreen.x > Screen.width / 2)
        {
            GameManager.Instance.PlayerScriptplayer.IsLookingRight = true;

        }
        else
        {
            GameManager.Instance.PlayerScriptplayer.IsLookingRight = false;

        }
        
    }
}
