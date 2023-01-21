using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Node _node;
    [SerializeField] Track _moved;
    float _speed;
    Rigidbody2D _rb2d;
    bool _isGoal;
    public bool OnGoal => _isGoal;

    void Awake()
    {
        if(_node == Node.Child) GameSystem.Instance.SetChildRunner(this);
        else GameSystem.Instance.SetRunner(this);
    }
    void Start()
    {
        _isGoal = false;
        _rb2d = GetComponent<Rigidbody2D>();
        _speed = speed;
    }

    void Update()
    {
        _rb2d.velocity = _moved == Track.Holizontal ? GoHolizontal() : GoVertual();
    }

    /// <summary>
    /// 横移動時に右向きに進める処理
    /// </summary>
    /// <returns></returns>
    private Vector3 GoHolizontal()
    {
        var velocity = this.transform.right;
        velocity = velocity.normalized * _speed;
        velocity.y = _rb2d.velocity.y;
        return velocity;
    }

    /// <summary>
    /// 縦移動時に上向きに進める処理
    /// </summary>
    /// <returns></returns>
    private Vector3 GoVertual()
    {
        var velocity = this.transform.up;
        velocity = velocity.normalized * _speed;
        return velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _speed = speed / 3;
        }
        else _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            _isGoal = true;
        }
    }


    /// <summary>
    /// オブジェクトを任意の個数出現させる
    /// </summary>
    /// <param name="runner">出現させるオブジェクト</param>
    /// <param name="spawnPos">出現させるポイント</param>
    /// <param name="count">出現させる数</param>
    public void Spawn(GameObject runner, Transform spawnPos, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(runner, spawnPos.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// 横移動か縦移動か決める
    /// </summary>
    enum Track
    {
        Holizontal,
        Vertual,
    }

    /// <summary>
    /// 親子関係の設定 
    /// </summary>
    enum Node
    {
        Parent,
        Child,
    }
}
