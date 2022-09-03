using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUP : Item
{
    [SerializeField] int count;
    [SerializeField] TextMeshPro text;
    private void Start()
    {
        text.text = count.ToString();
    }
    public override void Action(GameObject obj)
    {
        GameObject.Find("RunnerSpawn").GetComponent<RunnerSpawn>().Spawn(this.transform,count);
    }
}
