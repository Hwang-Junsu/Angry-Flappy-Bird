using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ManageGameAngry : ManageGame
{
    Transform _camera, _planks, _zero, _ball;
    Bomb _bomb;
    int remainEnemy;

    void Awake()
    {
        SetUI("Canvas");
        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        _planks = GameObject.Find("CapturePlank").GetComponent<Transform>();
        _zero = GameObject.Find("CaptureZero").GetComponent<Transform>();
        _ball = GameObject.Find("Ball").GetComponent<Transform>();
        _bomb = GameObject.Find("Ball").GetComponent<Bomb>();
    }

    void Start()
    {
        SetFade("Canvas");
        LoadData();
        displayBestScore();
        Invoke("GameIntro", 1.5f);
        Reset();
        FadeIn();
    }
    void Update()
    {
        displayLife();
        _txtScore.text = string.Format("Score : {0}", Score);
        if (gm == GameMode.GAME)
        {
            if (_ball.position.x >= 0f && _ball.position.x <= _planks.position.x) _camera.gameObject.GetComponent<CameraMove>().ObjectYFixedCamera(_ball);
        }
    }
    override public void GameStart()
    {
        PlankFocusCamera();
        Invoke("BallFocusCamera", 4.5f);
    }
    override public void SetGameOver()
    {
        SetGameOverUI();
        ManageApp.singleton.updateBestScore("AngryBird",score);
        ManageApp.singleton.Save();
        gm = GameMode.RESULT;
    }
    override public void displayBestScore()
    {
        _txtBestScore.text = string.Format("BestScore : {0}", ManageApp.singleton.BestScoreA);
    }

    public bool CheckClear()
    {
        if (remainEnemy > 0) return true;
        else return false;
    }
    void PlankFocusCamera()
    {
        _camera.SendMessage("ObjectFocusingCamera", _planks);
    }
    void BallFocusCamera()
    {
        _camera.gameObject.GetComponent<CameraMove>().StopCameraMoving();
        _camera.SendMessage("ObjectFocusingCamera", _zero);
        Invoke("SetGameMode", 2f);
    }
    void SetGameMode()
    {
        _camera.gameObject.GetComponent<CameraMove>().StopCameraMoving();
        _bomb.enabled = true;
        _bomb.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gm = GameMode.GAME;
    }

    public void RestartGame()
    {
        FadeOut(SceneManager.GetActiveScene().name);
    }

    public void CheckGameState()
    {
        if (CheckClear())
        {
            Life--;
            if (Life == 0)
            {
                SetGameOver();
                GameData.DataInit();
                return;
            }
            SaveData();
            RestartGame();
        } 
        else{
            SaveData();
            RestartGame();
        }
    }

    void Reset()
    {
        gm = GameMode.INTRO;
        _bomb.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        _bomb.enabled = false;
        remainEnemy = 3;
    }
    public int Remainenemy
    {
        get { return remainEnemy; }
        set { remainEnemy = value; }
    }

    public void SaveData()
    {
        GameData.life = life;
        GameData.score = score;
    }
    public void LoadData()
    {
        life = GameData.life;
        score += GameData.score;
    }
}
