using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    bool _isLookingRight;
    public bool IsLookingRight
    {
        get { return _isLookingRight; }
        set { if (value != _isLookingRight) transform.Rotate(new Vector3(0, 180, 0)); _isLookingRight = value; }
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) animator.SetTrigger("Attack");
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = JumpForce;

        if (!isTouchingFloor) y = 0;
        if (Input.GetAxis("Jump") == 0) y = 0;
        if (Rigidbody2D.velocity.y < 0f) animator.SetBool("Fall", true);

        Move(new Vector3(x, y, 0));
        //if (Rigidbody2D.velocity.x < -0.1f) IsLookingRight = false;
       // if (Rigidbody2D.velocity.x > 0.1f) IsLookingRight = true;
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