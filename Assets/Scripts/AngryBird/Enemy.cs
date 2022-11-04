using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator _anim;
    ManageGameAngry _mng;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _mng = GameObject.Find("GameManager").GetComponent<ManageGameAngry>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "PlankHorizontal" && collision.gameObject.transform.position.y > transform.position.y) ||
            collision.gameObject.name == "PlankVertical")
        {
            _anim.SetTrigger("explosion");
        }
    }
    void Destroy()
    {
        _mng.Remainenemy--;
        _mng.SetAddScore();
        Destroy(gameObject);
    }
}
