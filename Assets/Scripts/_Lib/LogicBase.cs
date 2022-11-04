using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicBase
{
    public LogicBase(int _width, int _height) { }

    int checkValue = -1;

    protected bool isSequential(int _data, ref int count)
    {
        if (_data == checkValue)
        {
            count++;
            return true;
        }
        else return false;
    }
    protected void setCheckValue(int _checkValue)
    {
        checkValue = _checkValue;
    }
}
