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
        GameSystem.Runner.Spawn(runner,spawnPos,spawnCount);
    }
}
