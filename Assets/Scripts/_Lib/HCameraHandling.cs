using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCameraHandling : MonoBehaviour
{
    Transform _camera;
    Vector3 vel = Vector3.zero;

    public void SetCamera()
    {
        _camera = GetComponent<Transform>();
    }
    public void ObjectYFixedCamera(Transform _obj)
    {
        _camera.position = new Vector3(_obj.position.x, _camera.position.y, -10);
    }
    public void ObjectFocusingCamera(Transform _obj)
    {
        StartCoroutine("Moving", _obj);
    }
    public void StopCameraMoving()
    {
        StopAllCoroutines();
    }

    IEnumerator Moving(Transform _obj)
    {
        while (true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_obj.position.x, transform.position.y, -10), ref vel, 0.4f);
            yield return null;
        }
    }
}
