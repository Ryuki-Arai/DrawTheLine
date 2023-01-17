using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUP : Item
{
    [SerializeField] int count;
    [SerializeField] TextMeshPro text;
    [SerializeField] GameObject spawnPoint;
    private void Start()
    {
        text.GetComponent<TextMeshPro>();
        text.text = count.ToString();
    }
    public override void Action(GameObject obj)
    {
        spawnPoint.GetComponent<RunnerSpawn>().Spawn(count);
    }
}
