using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : Item
{
    public override void Action()
    {
        GameSystem.Runner.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
