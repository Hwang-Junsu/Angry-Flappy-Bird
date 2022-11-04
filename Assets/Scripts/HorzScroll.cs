using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorzScroll : HScroll
{
    ManageGameFlappy _mng;
    void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        _mng = GameObject.Find("GameManager").GetComponent<ManageGameFlappy>();
    }
    void Update()
    {
        if(_mng.gm != GameMode.GAME)
        {
            setRigidbody(0f);
            StopScroll();
        }
    }
    void GameStart()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        setRigidbody(4f);
    }
}
