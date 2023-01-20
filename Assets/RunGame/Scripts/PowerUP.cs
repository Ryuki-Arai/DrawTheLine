using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUP : Item
{
    [SerializeField] GameObject childRunner;
    [SerializeField] Transform spawnPos;
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
        GameSystem.Runner.Spawn(childRunner, spawnPos, count);
    }
}
