using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Columns : MonoBehaviour
{
    private BoxCollider2D _box;
    private BoxCollider2D _upBox;
    private BoxCollider2D _downBox;
    private ManageGameFlappy _mng;

    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _upBox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        _downBox = transform.GetChild(1).GetComponent<BoxCollider2D>();
        _mng = GameObject.Find("GameManager").GetComponent<ManageGameFlappy>();
        _box.isTrigger = true;
        _upBox.isTrigger = true;
        _downBox.isTrigger = true;
    }

    private void Update()
    {
        if(_mng.beCollide && (_upBox.isTrigger && _downBox.isTrigger))
        {
            Invoke("SetIsTrigger", 1f);
        }
    }


    void SetIsTrigger()
    {
        _upBox.isTrigger = false;
        _downBox.isTrigger = false;
    }
}
