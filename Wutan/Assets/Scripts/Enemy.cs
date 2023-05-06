using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    public bool isDread;
    public float DreadDistance;
    [SerializeField] int TakeDamageForce;
    private void Start()
    {
        GameManager.Instance.Enemies.Add(this);
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.PlayerScriptplayer.transform.position.x < transform.position.x) IsLookingRight = false;
        else IsLookingRight = true;
        if (isDread)
        {
            if (Vector3.Distance(GameManager.Instance.PlayerScriptplayer.transform.position, transform.position) > DreadDistance)
                return;
            else animator.SetBool("Attack",true);
        }

        Vector3 direction;
        //If Distance from player >= maxDistance && Animation isn't active ActivateAttack
        if (Vector3.Distance(GameManager.Instance.PlayerScriptplayer.transform.position, transform.position) < GameManager.Instance.PlayerScriptplayer.MaxEnemyDistance && !animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", true);
            return;
        }
        else if (animator.GetBool("Attack")) return;
        if (GameManager.Instance.PlayerScriptplayer.transform.position.x > transform.position.x) { direction = Vector3.right; }
        else { direction = Vector3.left; }
        float x = direction.x * Speed * Time.deltaTime;

        float y = JumpForce;
        if (GameManager.Instance.PlayerScriptplayer.transform.position.y < transform.position.y) { y = 0; }

        if (!isTouchingFloor) y = 0;
        if (Rigidbody2D.velocity.y < 0.1f)
        {
            try { animator.SetBool("Fall", true); }
            catch { }
        }

        Move(new Vector3(x, 0, 0));
        Jump(new Vector3(0, y, 0));
        
        if (Mathf.Abs(x) > 0.1f)
        {
            try { animator.SetBool("Walk", true); }
            catch { }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.tag == "Weapon")
        {
            Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce,ForceMode2D.Impulse);
            //Debug.Log("Trigger");
            if (collision.gameObject.name=="Sword") GameManager.Instance.PlayerScriptplayer.Attack1.Play();
            animator.SetTrigger("Hit");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnTriggerEnter2D(collision.collider);
        if (collision.collider.tag == "Weapon")
        {
            Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce, ForceMode2D.Impulse);
            animator.SetTrigger("Hit");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Weapon")
        {
            Rigidbody2D.AddForce((collision.transform.position - transform.position) * -TakeDamageForce, ForceMode2D.Impulse);
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.Enemies.Remove(this);
    }
}
