using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadAttack : MonoBehaviour
{
    [SerializeField] AudioSource Attak;
    public void AttackTheUnit()
    {
        Attak.Play();
        GameManager.Instance.PlayerScriptplayer.Rigidbody2D.AddForce(transform.position- GameManager.Instance.PlayerScriptplayer.transform.position*-200);
    }
}
