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
        Spawn(spawnPos, spawnCount);
    }

    public void Spawn(Transform pos, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(runner, pos.position, Quaternion.identity);
        }
    }
}
