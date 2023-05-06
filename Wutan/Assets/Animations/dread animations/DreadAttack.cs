using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadAttack : MonoBehaviour
{
    public void AttackTheUnit()
    {
        GameManager.Instance.PlayerScriptplayer.Rigidbody2D.AddForce(transform.position- GameManager.Instance.PlayerScriptplayer.transform.position*-200);
    }
}
