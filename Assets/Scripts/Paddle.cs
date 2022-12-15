using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10.0f;

    protected Rigidbody2D _rigidbody;

    protected bool isFrozen = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0.0f);
        _rigidbody.velocity = Vector2.zero;

        ResetSize();
    }

    public void Freeze()
    {
        isFrozen = true;
        Invoke("UnFreeze", 2);
    }

    public void UnFreeze()
    {
        isFrozen = false;
    }

    public void Shrink()
    {
        transform.localScale -= new Vector3(0F, 0.5f, 0f);
        // Invoke("ResetSize", 10); feel it makes a more fun game to keep the size shrunk until the next point is won
    }

    public void Expand()
    {
        transform.localScale += new Vector3(0F, 1f, 0f);
        // Invoke("ResetSize", 10);
    }

    public void ResetSize()
    {
        transform.localScale = new Vector3(0.2F, 1.5f, 1f);
    }

}
