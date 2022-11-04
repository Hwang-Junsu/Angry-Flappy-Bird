using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class ManageApp : MonoBehaviour
{
    public static ManageApp singleton;

    private string game = "";
    private int bestScoreF = 0;
    private int bestScoreA = 0;

    private Dictionary<string, int[]> _scores = new Dictionary<string, int[]>(){
        {"FlappyBird", new int[10]}, {"AngryBird", new int[10]}
    };
    private Dictionary<string, string[]> _names = new Dictionary<string, string[]>(){
        {"FlappyBird", new string[10]}, {"AngryBird", new string[10]}
    };

    private string _defaultScores = "0,0,0,0,0,0,0,0,0,0";
    private string _defaultNames = "N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A";
    private string nickName = "";
    private int coin = 0;

    private void Awake()
    {

        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("nickName", nickName);
        PlayerPrefs.SetInt("bestScoreF", bestScoreF);
        PlayerPrefs.SetInt("bestScoreA", bestScoreA);
        PlayerPrefs.SetInt("coin", coin);

        string Flappyscores = DataToString(_scores["FlappyBird"]);
        string Flappynames = DataToString(_names["FlappyBird"]);
        string Angryscores = DataToString(_scores["AngryBird"]);
        string Angrynames = DataToString(_names["AngryBird"]);

        PlayerPrefs.SetString("FlappyScores", Flappyscores);
        PlayerPrefs.SetString("FlappyNames", Flappynames);
        PlayerPrefs.SetString("AngryScores", Angryscores);
        PlayerPrefs.SetString("AngryNames", Angrynames);

    }

    void Load()
    {
        game = SceneManager.GetActiveScene().name;
        nickName = PlayerPrefs.GetString("nickName", "");
        bestScoreF = PlayerPrefs.GetInt("bestScoreF", 0);
        bestScoreA = PlayerPrefs.GetInt("bestScoreA", 0);
        coin = PlayerPrefs.GetInt("coin", 0);

        string Flappyscores = PlayerPrefs.GetString("FlappyScores", _defaultScores);
        string Flappynames = PlayerPrefs.GetString("FlappyNames", _defaultNames);
        string Angryscores = PlayerPrefs.GetString("AngryScores", _defaultScores);
        string Angrynames = PlayerPrefs.GetString("AngryNames", _defaultNames);

        StringToData("FlappyBird", Flappyscores, Flappynames);
        StringToData("AngryBird", Angryscores, Angrynames);
    }

    string DataToString(int[] _data)
    {
        string temp = "" + _data[0];
        for(int i = 1; i < _data.Length; i++)
        {
            temp += "," + _data[i];
        }

        return temp;
    }
    string DataToString(string[] _data)
    {
        string temp = _data[0];
        for (int i = 1; i < _data.Length; i++)
        {
            temp += "," + _data[i];
        }

        return temp;
    }
    void StringToData(string _gameMode, string _scoreStr, string _nameStr)
    {
        string[] tmps = _nameStr.Split(',');
        string[] tmpi = _scoreStr.Split(',');
        for (int i = 0; i < 10; i++)
        {
            _names[_gameMode][i] = tmps[i];
            _scores[_gameMode][i] = Convert.ToInt32(tmpi[i]);
        }
    }

    public void SetData(string gameMode, int index, string name, int score)
    {
        _names[gameMode][index] = name;
        _scores[gameMode][index] = score;
    }

    public void GetData(string gameMode, int index, out string out_name, out int out_score)
    {
        out_name = _names[gameMode][index];
        out_score = _scores[gameMode][index];
    }

    public string[] getRankNameString(string _gameMode)
    {
        return _names[_gameMode];
    }
    public int[] getRankScoreString(string _gameMode)
    {
        return _scores[_gameMode];
    }

    public void updateBestScore(string game, int score)
    {
        if (game == "FlappyBird")
        {
            bestScoreF = (bestScoreF < score) ? score : bestScoreF;
        }
        if(game == "AngryBird")
        {
            bestScoreA = (bestScoreA < score) ? score : bestScoreA;
        }
    }

    public void AddCoin()
    {
        coin += 100;
    }

    public int BestScoreF
    {
        get{ return bestScoreF; }
        set{ bestScoreF = value;}
    }
    public int BestScoreA
    {
        get { return bestScoreA; }
        set { bestScoreA = value; }
    }
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }
    public string NickName
    {
        get{ return nickName; }
        set{ nickName = value; }
    }
    public string Game
    {
        get { return game; }
        set { game = value; }
    }
}
