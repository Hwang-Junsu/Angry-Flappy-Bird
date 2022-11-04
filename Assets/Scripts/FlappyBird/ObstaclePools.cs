using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePools : MonoBehaviour
{
    private GameObject _prefColumn;
    private GameObject[] _pColumns;
    private ManageGame _mng;
    private int _colPoolSize = 5;
    private int _currentColIndex = 0;
    private float _colSpawnRate = 3f;
    private float _spawnXPosition = 10f;
    private float _colYPositionMax = 3f;
    private float _colYPositionMin = -0.5f;

    void Start()
    {
        _mng = GameObject.Find("GameManager").GetComponent<ManageGame>();
        _prefColumn = Resources.Load("Columns") as GameObject;
        Invoke("InitColumnCreate", 3.5f);
    }

    void InitColumnCreate()
    {
        _pColumns = new GameObject[_colPoolSize];
        for(int i = 0; i < _pColumns.Length; i++)
        {
            _pColumns[i] = Instantiate(_prefColumn,
                new Vector2(-15, -25),
                Quaternion.identity);
            _pColumns[i].name = "Columns";
        }
        InvokeRepeating("Spawn", 0f, _colSpawnRate);
    }

    void Spawn()
    {
        if (_mng.gm != GameMode.GAME) return;

        float _y_position = Random.Range(_colYPositionMin, _colYPositionMax);
        _pColumns[_currentColIndex].transform.position = new Vector2(_spawnXPosition, _y_position);
        _currentColIndex = (_currentColIndex + 1) % _colPoolSize;
    }

}
