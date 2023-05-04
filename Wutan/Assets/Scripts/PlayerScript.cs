using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    private bool isTouchingFloor = true;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = JumpForce;
        if (!isTouchingFloor) y = 0;

        
        Move(new Vector3(x, 0, 0));
        Debug.Log(Input.GetAxis("Jump"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {

            isTouchingFloor = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {

            isTouchingFloor = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
