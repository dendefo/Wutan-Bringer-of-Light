using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAudio : MonoBehaviour
{
    [SerializeField] AudioSource bite;
    // Start is called before the first frame update
    public void PlayBite()
    {
        bite.Play();
    }
}