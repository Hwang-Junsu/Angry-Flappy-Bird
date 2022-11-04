using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicOmok : Logic2D
{
    protected override bool analyze(int _x, int _y, int _sw, int _lw)
    {
        int checkValue = player + 1;
        _sw = 0; _lw = width;
        for (int dir = 0; dir < 4; dir++)
        {
            analyzeDir(checkValue, dir, _x, _y, _sw, _lw);
            analyzeDir(checkValue, dir + 4, _x, _y, _sw, _lw);

            if (count == 4) return true;
            resetCount();
        }
        return false;
    }
    public LogicOmok(int _width, int _height) : base(_width, _height)
    {

    }

    public bool setData(int _x, int _y)
    {
        if (!isEmpty(_x, _y)) return false;
        bool fiveStone = analyze(_x, _y, 0, width);
        setValue(_x, _y, player + 1);
        setPlayer();
        return fiveStone;
    }// 오목에서 데이터 입력
}
