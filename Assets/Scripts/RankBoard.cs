using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankBoard : MonoBehaviour
{

    public Text _txtName;
    public Text _txtRankScore;
    string _gameType; int _gameScore;
    ManageGameAngry _mngA = null;
    ManageGameFlappy _mngF = null;

    void Start()
    {
        _gameType = SceneManager.GetActiveScene().name;
        if(_gameType == "AngryBird")
        {
            _mngA = GameObject.Find("GameManager").GetComponent<ManageGameAngry>();
            _gameScore = _mngA.Score;
        } else if(_gameType == "FlappyBird")
        {
            _mngF = GameObject.Find("GameManager").GetComponent<ManageGameFlappy>();
            _gameScore = _mngF.Score;
        }
        SetRank(_gameScore);
        ManageApp.singleton.Save();
        displayRank();
    }

    void SetRank(int _gameScore)
    {
        ManageApp.singleton.updateBestScore(ManageApp.singleton.Game, _gameScore);

        var list_name = new ArrayList();
        var list_score = new ArrayList();

        string out_name;
        int out_score;

        for(int i = 0; i < 10; i++)
        {
            ManageApp.singleton.GetData(_gameType, i, out out_name, out out_score);
            list_name.Add(out_name);
            list_score.Add(out_score);
        }

        for(int i = 0; i < 10; i++)
        {
            if(_gameScore > (int)list_score[i])
            {
                list_name.Insert(i, ManageApp.singleton.NickName);
                list_score.Insert(i, _gameScore);
                break;
            }
        }

        for(int i = 0; i < 10; i++)
        {
            ManageApp.singleton.SetData(_gameType, i, (string)list_name[i], (int)list_score[i]);
        }
        
    }

    void displayRank()
    {
        int[] _rank = ManageApp.singleton.getRankScoreString(_gameType);
        string[] _name = ManageApp.singleton.getRankNameString(_gameType);


        for(int i = 0; i < 10; i++)
        {
            _txtName.text += _name[i];
            _txtRankScore.text += _rank[i].ToString();

            if(i != 9)
            {
                _txtName.text += '\n';
                _txtRankScore.text += '\n';
            }
        }




    }
}
