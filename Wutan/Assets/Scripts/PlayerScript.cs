using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    private bool isTouchingFloor = true;
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = JumpForce;

        if (!isTouchingFloor) y = 0;
        if (Input.GetAxis("Jump") == 0) y = 0;
        if (Rigidbody2D.velocity.y < 0f) animator.SetBool("Fall", true);

        Move(new Vector3(x, y, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {
            animator.SetBool("Floored", true);
            isTouchingFloor = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {
            animator.SetTrigger("Jump");
            isTouchingFloor = false;
        }
    }
    public void ResetFallBool()
    {
        animator.SetBool("Fall", false);
    }
    public void ResetFlooredBool()
    {
        animator.SetBool("Floored", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
