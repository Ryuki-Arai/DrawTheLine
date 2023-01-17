using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawn : MonoBehaviour
{
    [SerializeField] GameObject runner;
    [SerializeField] Transform spawnPos;
    [SerializeField] int spawnCount;

    void Start()
    {
        Spawn(spawnCount);
    }

    public void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(runner, spawnPos.position, Quaternion.identity);
        }
    }
}
