using TMPro;
using UnityEngine;

public class PowerUP : Item
{
    [SerializeField] GameObject childRunner;
    [SerializeField] Transform spawnPos;
    [SerializeField] int maxCount;
    [SerializeField] TextMeshPro text;
    [SerializeField] GameObject spawnPoint;
    int count;
    private void Start()
    {
        text.GetComponent<TextMeshPro>();
        count = Random.Range(1, maxCount);
        text.text = count.ToString();
    }
    public override void Action()
    {
        GameSystem.Runner.Spawn(childRunner, spawnPos, count);
    }
}
