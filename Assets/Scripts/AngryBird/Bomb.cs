using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private CameraMove _camera;
    private SpringJoint2D _spring;
    private Vector2 _prev_velocity;

    private bool clickedOn = false;
    private Ray _rayToCatapult; // 최대 제한 거리 지정을 위한 레이.
    private float _maxLength = 3f; // 최대 거리
    public Transform _zeroPoint; // 원점

    private LineRenderer _lineback, _linefore;
    private bool _isShowLine = true;
    private bool isCollide = false;

    private ManageGameAngry _mng;


    private void Start()
    {
        _lineback = GameObject.Find("LineBack").GetComponent<LineRenderer>();
        _linefore = GameObject.Find("LineFore").GetComponent<LineRenderer>();
        _camera = GameObject.Find("Main Camera").GetComponent<CameraMove>();

        _rayToCatapult = new Ray(_zeroPoint.position, Vector3.zero);
        _rb2d = GetComponent<Rigidbody2D>();
        _spring = GetComponent<SpringJoint2D>();

        _mng = GameObject.Find("GameManager").GetComponent<ManageGameAngry>();
    }
    private void Update()
    {
        if(clickedOn)
        {
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPoint.z = 0f;

            Vector2 _newVector = mouseWorldPoint - _zeroPoint.position;
            if(_newVector.sqrMagnitude > _maxLength*_maxLength)
            {
                _rayToCatapult.direction = _newVector;
                mouseWorldPoint = _rayToCatapult.GetPoint(_maxLength);
            }
            transform.position = mouseWorldPoint;
        }
        if(_spring != null)
        {
            if(_prev_velocity.sqrMagnitude > _rb2d.velocity.sqrMagnitude)
            {
                Destroy(_spring);
                _rb2d.velocity = _prev_velocity;
            }
            if (clickedOn == false) _prev_velocity = _rb2d.velocity;
        }

        updateLine();
    }

    private void OnMouseDown()
    {
        clickedOn = true;
    }
    private void OnMouseUp()
    {
        clickedOn = false;

        deleteLine();
        _rb2d.bodyType = RigidbodyType2D.Dynamic;

    }

    void updateLine()
    {
        if (!_isShowLine) return;

        _lineback.SetPosition(1, transform.position);
        _linefore.SetPosition(1, transform.position);
    }

    void deleteLine()
    {

        _isShowLine = false;
        _lineback.gameObject.SetActive(false);
        _linefore.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCollide) return;
        Invoke("GameOver", 5f);
        isCollide = true;
    }

    void GameOver()
    {
        _mng.CheckGameState();
    }
}
