using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public float timeFromStart = 0;
    
    void Update()
    {
        timeFromStart += Time.deltaTime;
        if (timeFromStart > 10) Destroy(gameObject);
    }
}
