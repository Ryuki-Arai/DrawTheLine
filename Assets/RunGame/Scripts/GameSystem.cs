using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{
    static private GameSystem _instance = new GameSystem();
    static public GameSystem Instance => _instance;
    private GameSystem() { }

    List<Runner> _runner = new List<Runner>();
    static public List<Runner> Runner => _instance._runner;
    public void SetRunner(Runner r) { _runner.Add(r); }
    public void DeleteRunnner(Runner r) { _runner.Remove(r); }

    List<Item> _item = new List<Item>();
    static public List<Item> Item => _instance._item;
    public void SetItem(Item item) { _item.Add(item); }
    public void DeleteItem(Item item) { _item.Remove(item); }

    public void RemoveData()
    {
        Runner.Clear();
        _item.Clear();
    }

    int _level = 1;
    static public int Level => _instance._level;
    public void LevelUP() { _level++; }
}
