using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProjectile : MonoBehaviour
{

    public ParticleSystem particleSystem;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            particleSystem.Play();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        int events = particleSystem.GetCollisionEvents(other, colEvents);

        //Debug.Log("particle fired");

        for(int i = 0; i < events; i++)
        {

        }
    }
}
