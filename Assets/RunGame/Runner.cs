using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rb2d;

    void Awake()
    {
        GameSystem.Instance.SetRunner(this);
    }
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var velocity = this.transform.right;
        velocity = velocity.normalized * _speed;
        velocity.y = _rb2d.velocity.y;
        _rb2d.velocity = velocity;
    }
}
