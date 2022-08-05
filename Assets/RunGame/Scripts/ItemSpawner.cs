using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject powerUPItem;
    [SerializeField] GameObject[] coinsPrefab;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] int _level;
    Transform[] point;

    void Start()
    {
        if(_level != GameSystem.Level)
        {
            _level = GameSystem.Level;
            Debug.Log($"{_level} : { GameSystem.Level}");
            point = new Transform[10 + _level / 2];
            for (int i = 0; i < point.Length; i++)
            {
                point[i] = spawnPoint[Random.Range(0, spawnPoint.Length)];
            }
            for (int i = 0; i < point.Length; i++)
            {
                var item = Instantiate(coinsPrefab[Random.Range(0, coinsPrefab.Length)], point[i]);

            }
        }
    }
}
