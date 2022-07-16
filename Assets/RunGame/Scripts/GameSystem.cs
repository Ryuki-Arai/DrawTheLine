using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{
    static private GameSystem _instance = new GameSystem();
    static public GameSystem Instance => _instance;
    private GameSystem() { }

    Runner _runner;
    static public Runner Runner => _instance._runner;
    public void SetRunner(Runner r) { _runner = r; }

    List<Item> _item = new List<Item>();
    static public List<Item> Item => _instance._item;
    public void SetItem(Item item) { _item.Add(item); }
    public void DeleteItem(Item item) { _item.Remove(item); }
}
