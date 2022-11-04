using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HScroll : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public void setRigidbody(float _speed)
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.bodyType = RigidbodyType2D.Kinematic;
        _rb2d.velocity = new Vector2(-_speed, 0f);
    }
    public void StopScroll()
    {
        _rb2d.velocity = Vector2.zero;
    }
    public void GoScroll(float _speed)
    {
        _rb2d.velocity = new Vector2(_speed, 0f);
    }
}
