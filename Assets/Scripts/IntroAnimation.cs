using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;

    void Awake()
    {
        two.SetActive(false);
        one.SetActive(false);
        go.SetActive(false);
    }

    void Start()
    {
        StartCoroutine("CountAnimation");
    }

    IEnumerator CountAnimation()
    {
        yield return new WaitForSeconds(1f);
        two.SetActive(true);
        yield return new WaitForSeconds(1f);
        one.SetActive(true);
        yield return new WaitForSeconds(1f);
        go.SetActive(true);
        yield return new WaitForSeconds(1f);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("HorzScroll");
        if (SceneManager.GetActiveScene().name == "FlappyBird")
        {
            foreach (var o in objs)
            {
                o.SendMessage("GameStart");
            }
            GameObject.Find("Bird").SendMessage("GameStart");
        }
        GameObject.Find("GameManager").SendMessage("GameStart");
 
        Destroy(gameObject);
    }

}
