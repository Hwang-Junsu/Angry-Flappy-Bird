using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMaker : MonoBehaviour
{
    GameObject _plank, _hplank, _enemy;
    GameObject spawnSpot;
    Transform _planks;
    public int[] plank = new int[3];
    int[] enemy = new int[3];

    private void Awake()
    {
       _plank = Resources.Load("Plank") as GameObject;
       _hplank = Resources.Load("PlankHalf") as GameObject;
        _enemy = Resources.Load("Enemy") as GameObject;
        spawnSpot = GameObject.Find("Planks");
        _planks = GameObject.Find("CapturePlank").GetComponent<Transform>();
    }

    private void Start()
    {
        RandomSize();
        MakePlank();
        _planks.position = new Vector3(_planks.position.x -1f+ (((_plank.GetComponent<BoxCollider2D>().size.x / 2f) * plank[0])), _planks.position.y, _planks.position.z);
    }

    void RandomSize()
    {
        for(int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                plank[i] = Random.Range(1, 9);
                enemy[i] = Random.Range(1, plank[i]+1);
            }
            else
            {
                plank[i] = Random.Range(1, plank[i - 1]);
                enemy[i] = Random.Range(1, plank[i]+1);
            }
        }
    }

    void MakePlank()
    {
        float _plankWid = _plank.GetComponent<BoxCollider2D>().size.x;
        float _plankHei = _plank.GetComponent<BoxCollider2D>().size.y;
        float spawnPositionX = spawnSpot.transform.position.x;
        float spawnPositionY = spawnSpot.transform.position.y;
        float interval = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < plank[i]; j++)
            {
                if (j == 0) Instantiate(_plank, new Vector2(spawnPositionX + (_plankWid * j) + interval, spawnPositionY + (_plankHei * i)), Quaternion.identity);
                else Instantiate(_hplank, new Vector2(spawnPositionX + (_plankWid * j) + interval, spawnPositionY + (_plankHei * i)), Quaternion.identity);

                if(enemy[i] == j+1)
                {
                    Instantiate(_enemy, new Vector2(spawnPositionX + (_plankWid * j) + interval, spawnPositionY + (_plankHei * i)-0.01f), Quaternion.identity);
                }
                
            }
            if(i!=2) interval += ((_plankWid / 2) * (plank[i] - plank[i+1]));
        }
    }
}
