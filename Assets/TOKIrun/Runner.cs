using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rb2d;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
