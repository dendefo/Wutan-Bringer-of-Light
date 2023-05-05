using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float timeFromStart = 0;
    private void Update()
    {
        timeFromStart+= Time.deltaTime;
        if(timeFromStart>6) Destroy(gameObject);
    }
    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
    
}
