using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer Renderer;
    [SerializeField] protected Collider2D Collider;
    [SerializeField] protected Rigidbody2D Rigidbody2D;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float Speed;
    [SerializeField] protected float JumpForce;
    protected bool isTouchingFloor = true;
    protected void Move(Vector3 direction)
    {
        Rigidbody2D.AddForce(direction);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="DeleteEnemy") Destroy(gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {
            try { animator.SetBool("Floored", true); }
            catch { }
            isTouchingFloor = true;
        }

    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor" && transform.position.y > collision.transform.position.y)
        {
            try
            {
                animator.SetTrigger("Jump");
            }
            catch { }
            isTouchingFloor = false;
        }
    }
}
