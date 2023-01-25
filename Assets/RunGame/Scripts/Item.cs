using UnityEngine;
/// <summary>
/// �t�B�[���h��ɔz�u�����A�C�e���̐e�N���X
/// �p������Action�֐��ɕK�v�ȏ���������
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
    /// �擾���̏���
    /// </summary>
    public abstract void Action();
}
