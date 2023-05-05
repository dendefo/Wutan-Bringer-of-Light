using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public Vector3 TargetPosition;
    public Vector3 StartPosition;
    public float LiveTime;
    public float timeAtStart;
    void Awake()
    {
        TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartPosition = transform.position;
        timeAtStart= Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position= Vector3.Lerp(StartPosition,TargetPosition,(Time.time-timeAtStart)/LiveTime);
        if (Time.time -timeAtStart > LiveTime) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag=="Player"|| collision.tag == "Weapon" ))Destroy(gameObject);

    }
}
