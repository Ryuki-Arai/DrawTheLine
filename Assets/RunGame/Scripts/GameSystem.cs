using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{
    static private GameSystem _instance = new GameSystem();
    static public GameSystem Instance => _instance;
    private GameSystem() { }

    Runner runner = default;
    static public Runner Runner => _instance.runner;
    public void SetRunner(Runner r) { runner = r; }

    List<Runner> _childRunner = new List<Runner>();
    static public List<Runner> ChildRunner => _instance._childRunner;
    public void SetChildRunner(Runner r) { _childRunner.Add(r); }
    public void DeleteChildRunnner(Runner r) { _childRunner.Remove(r); }

    List<Item> _item = new List<Item>();
    static public List<Item> Item => _instance._item;
    public void SetItem(Item item) { _item.Add(item); }
    public void DeleteItem(Item item) { _item.Remove(item); }

    int _point;
    public int Point
    {
        get => _point;
        set => _point = value;
    }

    public void RemoveData()
    {
        ChildRunner.Clear();
        _item.Clear();
    }

    int _level = 1;
    static public int Level => _instance._level;
    public void LevelUP() { _level++; }
}
