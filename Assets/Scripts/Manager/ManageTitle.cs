using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageTitle : Manager
{

    public GameObject input;
    public GameObject btnAddCoin;
    public GameObject settings;
    public Text txtBtnName,txtBestScore,txtNickName,txtUser,txtCoin,txtInSettingName,txtInSettingCoin;
    bool status = false;

    void Awake()
    {
        SetFade("Canvas");
        settings.SetActive(false);
        input.SetActive(false);
    }
    void Start()
    {
        FadeIn();
    }

    void Update()
    {
        txtCoin.text = string.Format("COIN : {0}", ManageApp.singleton.Coin);
        txtInSettingCoin.text = string.Format("COIN : {0}", ManageApp.singleton.Coin);
        txtNickName.text = string.Format("PLAYER : {0}", (ManageApp.singleton.NickName == "") ? "none" : ManageApp.singleton.NickName);
        txtInSettingName.text = string.Format("PLAYER : {0}", ManageApp.singleton.NickName);
        txtBestScore.text = string.Format("BEST SCORE : F({0}), A({1})", ManageApp.singleton.BestScoreF, ManageApp.singleton.BestScoreA);
    }
    public void ClickNameButton()
    {
        status = !status;
        txtBtnName.text = (status) ? "Okay" : "Name";
        input.SetActive(status);

        if(status == false && txtUser.text != "")
        {
            ManageApp.singleton.NickName = txtUser.text;
            ManageApp.singleton.Save();

            txtNickName.text = string.Format("nickname : {0}", txtUser.text);
            txtUser.text = "";
        }
    }

    public void ClickSettings()
    {
        if (!settings.activeInHierarchy) settings.SetActive(true);
        else settings.SetActive(false);
    }

    public void ClickAddCoin()
    {
        ManageApp.singleton.AddCoin();
        ManageApp.singleton.Save();
    }

    public void ClickPlayGame(string _game)
    {
        if (ManageApp.singleton.NickName == "") return;
        if (ManageApp.singleton.Coin < 500) return;
        ManageApp.singleton.Coin -= 500;
        ManageApp.singleton.Save();
        FadeOut(_game);
    }
}
