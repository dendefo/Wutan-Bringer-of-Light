using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer Renderer;
    [SerializeField] protected Collider2D Collider;
    [SerializeField] protected Rigidbody2D Rigidbody2D;
    [SerializeField] protected float Speed;

    protected void Move(Vector3 direction)
    {
        Rigidbody2D.AddForce(direction);
    }
}
