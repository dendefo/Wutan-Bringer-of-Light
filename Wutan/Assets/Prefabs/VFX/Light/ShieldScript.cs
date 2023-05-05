using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float timeFromStart = 0;
    private void Update()
    {
        timeFromStart+= Time.deltaTime;
        if(timeFromStart>10) Destroy(gameObject);
        transform.position = GameManager.Instance.PlayerScriptplayer.Stuuf.transform.position;
        transform.position= new(transform.position.x,transform.position.y-12);

    }
    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
    
}
