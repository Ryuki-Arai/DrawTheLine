using UnityEngine;
/// <summary>
/// フィールド状に配置されるアイテムの親クラス
/// 継承してAction関数に必要な処理を書く
/// </summary>
public abstract class Item : MonoBehaviour
{
    private void Awake()
    {
        GameSystem.Instance.SetItem(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSystem.Instance.DeleteItem(this);
        Action();
        Destroy(this.gameObject);
    }
    /// <summary>
    /// 取得時の処理
    /// </summary>
    public abstract void Action();
}
