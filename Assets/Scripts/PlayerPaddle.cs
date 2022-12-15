using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;

    // Update is called every frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            _direction = Vector2.up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            _direction = Vector2.down;
        else
            _direction = Vector2.zero;
    }

    // FixedUpdate is for updating at a fixed time interval, for physics
    private void FixedUpdate()
    {
        if (this.isFrozen)
            return;

        if (_direction.sqrMagnitude != 0)
            _rigidbody.AddForce(_direction * this.speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.SetHitLast(1);
        }
    }
}
