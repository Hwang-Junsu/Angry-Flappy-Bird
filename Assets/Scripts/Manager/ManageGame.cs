using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


abstract public class ManageGame : Manager
{
    public GameMode gm = GameMode.INTRO;
    protected int life = 3;
    protected int score = 0;

    abstract public void GameStart();
    abstract public void SetGameOver();
    abstract public void displayBestScore();

    public void SetAddScore()
    {
        Score += 10;
        _txtScore.text = string.Format("Score : {0}", Score);
    }
    public void displayLife()
    {
        _txtLife.text = string.Format("Life : {0}", Life);
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    
    public int Life
    {
        get { return life; }
        set { life = value; }
    }

}
