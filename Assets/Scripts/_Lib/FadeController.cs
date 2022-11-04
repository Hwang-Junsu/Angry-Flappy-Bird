using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    private Animator _anim;
    string _sceneName;

    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetSceneName(string _scene)
    {
        _sceneName = _scene;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ActiveSetting()
    {
        gameObject.SetActive(false);
    }
}
