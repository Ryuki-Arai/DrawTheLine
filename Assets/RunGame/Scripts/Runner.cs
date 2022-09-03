using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‰¡ˆÚ“®‚©cˆÚ“®‚©Œˆ‚ß‚é
/// </summary>
public enum Track
{
    Holizontal,
    Vertual,
}

public class Runner : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Track _moved;
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
        Vector3 velocity = default;
        if (_moved == Track.Holizontal) velocity = GoHolizontal();
        else if (_moved == Track.Vertual) velocity = GoVertual();
        _rb2d.velocity = velocity;
    }

    /// <summary>
    /// ‰¡ˆÚ“®‚É‰EŒü‚«‚Éi‚ß‚éˆ—
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
    /// cˆÚ“®‚ÉãŒü‚«‚Éi‚ß‚éˆ—
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
}
