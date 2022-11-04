using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    private Rigidbody2D _rb2d;
    private Animator _anim;
    private SpriteRenderer _sr;
    private PolygonCollider2D _coll;
    private bool immortal = false;
    private ManageGameFlappy _mng;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _coll = GetComponent<PolygonCollider2D>();

        _rb2d.bodyType = RigidbodyType2D.Kinematic;
        _mng = GameObject.Find("GameManager").GetComponent<ManageGameFlappy>();
    }

    void Update()
    {
        if(_mng.gm != GameMode.GAME) return;

        if (Input.GetMouseButtonDown(0))
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(new Vector2(0f, upForce));
            _anim.SetTrigger("SetFlap");
        }
    }

    void GameStart()
    {
        _rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immortal)
        {
            if (collision.name == "Column Up" || collision.name == "Column Down")
            {
                if (_mng.Life > 0)
                {
                    _mng.Life--;
                    StartCoroutine("BirdHit");
                }
            }
            else if (collision.name == "Columns")
            {
                _mng.SetAddScore();
            };
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_mng.gm == GameMode.GAME)
        {
            _mng.SetGameOver();
            _anim.SetTrigger("SetDie");
        }
    }


    IEnumerator BirdHit()
    {
        immortal = true;
        for (int i = 0; i < 6; i++)
        {
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.2f);
            yield return new WaitForSeconds(0.1f);
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        immortal = false;
    }
}
