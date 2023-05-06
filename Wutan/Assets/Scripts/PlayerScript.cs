using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    [SerializeField] public float MaxEnemyDistance;
    [SerializeField] public Transform Stuuf;
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


        Move(new Vector3(x, 0, 0));
        Jump(new Vector3(0, y, 0));
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
