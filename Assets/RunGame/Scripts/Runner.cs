using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float speed;
    float _speed;
    Rigidbody2D _rb2d;
    bool _isGoal;
    public bool OnGoal => _isGoal;

    void Awake()
    {
        GameSystem.Instance.SetRunner(this);
    }
    void Start()
    {
        _isGoal = false;
        _rb2d = GetComponent<Rigidbody2D>();
        _speed = speed;
    }

    void Update()
    {
        var velocity = this.transform.right;
        velocity = velocity.normalized * _speed;
        velocity.y = _rb2d.velocity.y;
        _rb2d.velocity = velocity;
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
            GameSystem.Instance.LevelUP();
        }
    }
}
