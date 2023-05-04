using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = Input.GetAxis("Jump")*JumpForce* Time.deltaTime;
        Move(new Vector3(x, y, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
