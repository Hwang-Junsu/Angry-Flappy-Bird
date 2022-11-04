using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logic2D : LogicBase
{

    int[,] dat;
    int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 };
    int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };

    protected int count;
    protected int player;
    protected int width, height;
    protected (int, int)[] vPoint = new (int, int)[100];
    protected (int, int)[] vIndex = new (int, int)[100];

    protected void setPlayer()
    {
        player = 1 - player;
    } // 플레이어 바꾸기


    protected bool analyzeDir(int _checkValue, int _dir, int _x, int _y, int _sw, int _lw)
    {
        setCheckValue(_checkValue);
        for (int nx = _x, ny = _y; (0 <= nx && nx <= height) && (_sw <= ny && ny <= _lw);
            nx += dx[_dir], ny += dy[_dir])
        {
            if (nx == _x && ny == _y) continue;
            if (!isSequential(dat[nx, ny], ref count)) return (dat[nx, ny] == 0);
            else
            {
                int index = count - 1;
                vPoint[index].Item1 = nx;
                vPoint[index].Item2 = ny;
            }
        }
        return true;

    }// 2차원 공간 분석


    protected bool isEmpty(int _x, int _y)
    {
        return (dat[_x, _y] == 0);
    }

    protected abstract bool analyze(int _x, int _y, int _sw, int _lw);
    protected int getValue(int _xPos, int _yPos)
    {
        return dat[_xPos, _yPos];
    }
    protected void setValue(int _xPos, int _yPos, int _color)
    {
        dat[_xPos, _yPos] = _color;
    }
    protected void resetCount()
    {
        count = 0;
    }

    public int getPlayer()
    {
        return player;
    }

    public int[,] getDat()
    {
        return dat;
    }
    public Logic2D(int _width, int _height) : base(_width, _height)
    {
        player = 0;
        width = _width; height = _height;
        dat = new int[width, height];
    }
}
