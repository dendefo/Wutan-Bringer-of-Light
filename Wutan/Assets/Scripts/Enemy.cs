using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void Start()
    {
        GameManager.Instance.Enemies.Add(this);
    }
    private void FixedUpdate()
    {
        Vector3 direction;
        if (GameManager.Instance.PlayerScriptplayer.transform.position.x>transform.position.x) { direction = Vector3.right; }
        else { direction = Vector3.left; }
        float x = direction.x * Speed * Time.deltaTime;

        float y = JumpForce;
        if (GameManager.Instance.PlayerScriptplayer.transform.position.y< transform.position.y) { y = 0; }

        if (!isTouchingFloor) y = 0;
        if (Rigidbody2D.velocity.y < 0f)
        {
            try { animator.SetBool("Fall", true); }
            catch { }
        }

        Move(new Vector3(x, y, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Weapon") Rigidbody2D.AddForce(collision.transform.position - transform.position*-100);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnTriggerEnter2D(collision.collider);
        if (collision.collider.tag == "Weapon") Rigidbody2D.AddForce(collision.transform.position - transform.position * -100);
    }
}
