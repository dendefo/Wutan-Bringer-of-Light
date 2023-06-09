using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] int TakeDamageForce;
    private void Start()
    {
        GameManager.Instance.Enemies.Add(this);
    }
    private void FixedUpdate()
    {
        Vector3 direction;
        //If Distance from player >= maxDistance && Animation isn't active ActivateAttack
        if (Vector3.Distance(GameManager.Instance.PlayerScriptplayer.transform.position,transform.position) < GameManager.Instance.PlayerScriptplayer.MaxEnemyDistance) { return; }
        if (GameManager.Instance.PlayerScriptplayer.transform.position.x > transform.position.x) { direction = Vector3.right; }
        else { direction = Vector3.left; }
        float x = direction.x * Speed * Time.deltaTime;

        float y = JumpForce;
        if (GameManager.Instance.PlayerScriptplayer.transform.position.y < transform.position.y) { y = 0; }

        if (!isTouchingFloor) y = 0;
        if (Rigidbody2D.velocity.y < 0f)
        {
            try { animator.SetBool("Fall", true); }
            catch { }
        }

        Move(new Vector3(x, 0, 0));
        Jump(new Vector3(0, y, 0));
        if (GameManager.Instance.PlayerScriptplayer.transform.position.x < transform.position.x) IsLookingRight = false;
        else IsLookingRight = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.tag == "Weapon")
        {
            Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce);
            Debug.Log("Trigger");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnTriggerEnter2D(collision.collider);
        if (collision.collider.tag == "Weapon") Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Weapon") Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce);
    }
    private void OnDestroy()
    {
        GameManager.Instance.Enemies.Remove(this);
    }
}
