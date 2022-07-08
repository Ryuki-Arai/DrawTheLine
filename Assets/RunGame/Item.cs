using UnityEngine;

public class Item : MonoBehaviour
{
    private void Awake()
    {
        GameSystem.Instance.SetItem(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSystem.Instance.DeleteItem(this);
        Destroy(this.gameObject);
    }
}
