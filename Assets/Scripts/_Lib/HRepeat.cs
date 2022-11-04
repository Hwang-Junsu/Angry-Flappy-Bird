using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HRepeat : MonoBehaviour
{
    private BoxCollider2D _box;
    private float _groundHorizontalLength;

    public void setBoxCollider()
    {
        _box = GetComponent<BoxCollider2D>();
        _groundHorizontalLength = _box.size.x;
    }
    public void updateObject()
    {
        if (transform.position.x < -_groundHorizontalLength)
            ResetPosition();
    }
    public void ResetPosition()
    {
        Vector2 addPos = new Vector2(2 * _groundHorizontalLength, 0f);
        transform.position = (Vector2)transform.position + addPos;
    }
}
