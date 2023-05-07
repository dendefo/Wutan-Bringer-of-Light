using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    public int MaxHP;
    public int CurrentHp;
    [SerializeField] public float MaxEnemyDistance;
    [SerializeField] public Transform Stuuf;
    public AudioSource Attack1;
    [SerializeField] AudioSource Attack2;
    [SerializeField] public AudioSource Attack3;
    public float StickAngle;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) animator.SetTrigger("Attack");
        if (Input.GetAxis("Attack")!=0) animator.SetTrigger("Attack");
        float x = Input.GetAxis("Joystick Horizontal");
        float y = Input.GetAxis("Joystick Vertical");
        Vector2 NormalJoystick = new Vector2(x, y);
        NormalJoystick.Normalize();
        float angle = Mathf.Acos(NormalJoystick.y) / Mathf.PI * 180;
        if (x < 0) angle = 360 - angle;
        StickAngle= angle;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.tag == "Enemy")
        {
            CurrentHp--;
            animator.SetTrigger("Hit");
            Attack3.Play();
        }

        if (CurrentHp <= 0) GameManager.Instance.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeleteEnemy") GameManager.Instance.Die();
    }
    public void PlayAttackSound()
    {
        Attack2.Play();
    }
    public void ResetAttackTrigger()
    {
        animator.ResetTrigger("Attack");
    }
}
