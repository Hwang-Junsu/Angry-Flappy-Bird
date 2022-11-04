using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData
{
    public static int life = 3;
    public static int score = 0;


    public static void DataInit()
    {
        life = 3;
        score = 0;
    }
}
