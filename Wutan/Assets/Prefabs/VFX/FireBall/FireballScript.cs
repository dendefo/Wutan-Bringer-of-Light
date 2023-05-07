using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireballScript : MonoBehaviour
{
    public Vector3 TargetPosition;
    public Vector3 StartPosition;
    public float LiveTime;
    public float timeAtStart;
    public float Speed;
    [SerializeField] AudioSource Fly;
    void Awake()
    {
        StartPosition = transform.position;
        TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)-StartPosition;
        TargetPosition = Vector3.Normalize(TargetPosition);
        float x;
        float y;

        if (Gamepad.current != null)
        {
            if (Gamepad.current.layout == "XInputController")
            {
                x = Input.GetAxis("Joystick Horizontal1");
                y = Input.GetAxis("Joystick Vertical1");
            }
            else
            {
                x = Input.GetAxis("Joystick Horizontal");
                y = Input.GetAxis("Joystick Vertical");
            }
        }
        else
        {
            x = Input.mousePosition.x - Screen.width / 2;
            y = Input.mousePosition.y - Screen.height / 2;
        }
        Vector2 NormalJoystick = new Vector2(x, y);
        NormalJoystick.Normalize();
        TargetPosition = NormalJoystick*Speed;


        timeAtStart = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - timeAtStart > 1) Fly.Play();
        transform.position= Vector3.LerpUnclamped(StartPosition,TargetPosition,(Time.timeSinceLevelLoad-timeAtStart)/LiveTime);
        if (Time.timeSinceLevelLoad -timeAtStart > LiveTime) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!(collision.tag=="Player"|| collision.tag == "Weapon" ))Destroy(gameObject);

    }
}
