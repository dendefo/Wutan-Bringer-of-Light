using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] BoxCollider2D BoxCollider2D;

    [Min(0)] public int Length;
    const float height = 10.5f;
    const float ColliderHeight = 3.186626f;
    // Start is called before the first frame update
    void Awake()
    {
        ChangeSize();
        
    }
    private void OnValidate()
    {
        ChangeSize();
    }
    void ChangeSize()
    {
        sprite.size = new Vector2(8.4f + (10 * Length), height);
        BoxCollider2D.size = new Vector2(4.45f+(10*Length),ColliderHeight);
    }
}
