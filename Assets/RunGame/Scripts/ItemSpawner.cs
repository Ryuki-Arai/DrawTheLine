using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] int _level;
    [SerializeField] GameObject powerUPItem;
    [SerializeField] GameObject[] coinsPrefab;
    [SerializeField] SpawnPos[] spawnPoint;
    Transform[] point;
    [System.Serializable]
    public class SpawnPos
    {
        public Transform[] spawnPos;
    }

    void Start()
    {
        if(_level != GameSystem.Level)
        {
            _level = GameSystem.Level;
            Debug.Log($"{_level} : { GameSystem.Level}");
            point = new Transform[spawnPoint.Length * spawnPoint[0].spawnPos.Length];
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                for(int j = 0; j < point.Length/spawnPoint.Length; j++)
                {
                    point[i] = spawnPoint[i].spawnPos[Random.Range(0, spawnPoint[i].spawnPos.Length)];
                }
            }
            for (int i = 0; i < point.Length; i++)
            {
                var item = Instantiate(coinsPrefab[Random.Range(0, coinsPrefab.Length)], point[i]);

            }
        }
    }
}
