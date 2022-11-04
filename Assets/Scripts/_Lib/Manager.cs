using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameMode
{
    INTRO,
    GAME,
    RESULT,
}

public class Manager : MonoBehaviour
{
    GameObject _fadePrefab, _fade;
    RectTransform canvas;
    GameObject _intro;

    protected GameObject _pGameOver;
    protected RankBoard rank;

    GameObject _ui;
    protected Text _txtScore, _txtBestScore, _txtLife;


    // Fade Instantiate
    public void SetFade(string _parent)
    {
        _fadePrefab = Resources.Load("Fade") as GameObject;
        canvas = GameObject.Find(_parent).GetComponent<RectTransform>();
    }
    public void FadeIn()
    {   
        _fade = Instantiate(_fadePrefab, canvas.localPosition, Quaternion.identity, canvas.gameObject.transform);
        _fade.name = "Fade";
    }
    public void FadeOut(string _sceneName)
    {
        _fade.SetActive(true); _fade.GetComponent<Animator>().SetTrigger("FadeOut");
        _fade.GetComponent<FadeController>().SetSceneName(_sceneName);
    }

    // Intro Instantiate
    public void GameIntro()
    {
        _intro = Resources.Load("Intro") as GameObject;
        Instantiate(_intro, Vector2.zero, Quaternion.identity);
    }

    // UI
    public void SetGameOverUI()
    {
        _pGameOver = Resources.Load("GameOverUI") as GameObject;

        Transform _transUI = GameObject.Find("UI").GetComponent<Transform>();
        GameObject _obj = Instantiate(_pGameOver, canvas.localPosition, Quaternion.identity, _transUI);
        _obj.name = "GameOverUI";

        rank = GameObject.Find("txtRankBoard").GetComponent<RankBoard>();
    }

    public void ClickMainButton()
    {
        GameObject.Find("GameManager").SendMessage("FadeOut", "Title");
    }
    public void ClickRetry()
    {
        if (ManageApp.singleton.Coin < 500) return;
        ManageApp.singleton.Coin -= 500;
        ManageApp.singleton.Save();
        GameObject.Find("GameManager").SendMessage("FadeOut", SceneManager.GetActiveScene().name);
    }

    public void SetUI(string _parent)
    {
        canvas = GameObject.Find(_parent).GetComponent<RectTransform>();
        _ui = Resources.Load("UI") as GameObject;
        GameObject _obj = Instantiate(_ui, canvas.localPosition, Quaternion.identity, canvas.gameObject.transform);
        _obj.name = "UI";

        _txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        _txtBestScore = GameObject.Find("txtBestScore").GetComponent<Text>();
        _txtLife = GameObject.Find("txtLife").GetComponent<Text>();
    }

}
