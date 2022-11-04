using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameFlappy : ManageGame
{

    public bool beCollide = false;

    void Awake()
    {
        SetUI("Canvas");
        gm = GameMode.INTRO;
    }
    void Start()
    {
        SetFade("Canvas");
        FadeIn();
        displayBestScore();
        Invoke("GameIntro", 1f);
    }
    void Update()
    {
        displayLife();
        if (Life == 0)
        {
            ColumnsTriggerOn();
        }
    }
    override public void GameStart()
    {
        gm = GameMode.GAME;
    }
    override public void SetGameOver()
    {
        SetGameOverUI();
        ManageApp.singleton.updateBestScore("FlappyBird",score);
        ManageApp.singleton.Save();
        gm = GameMode.RESULT;
    }
    override public void displayBestScore()
    {
        _txtBestScore.text = string.Format("BestScore : {0}", ManageApp.singleton.BestScoreF);
    }

    void ColumnsTriggerOn()
    {
        beCollide = true;
    }
}
