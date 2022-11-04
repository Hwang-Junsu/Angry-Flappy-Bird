using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : HRepeat
{
    void Start()
    {
        setBoxCollider();
    }

    void Update()
    {
        updateObject();
    }
}
