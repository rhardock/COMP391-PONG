using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float stayTime = 5f;
    public float randomMin = 1f;
    public float randomMax = 5f;
    public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;

    private int powerUpType = 0;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.SetActive(false);
        Invoke("Show", Random.Range(randomMin, randomMax));
    }

    private void Show()
    {
        // change the position in Y each time
        Vector3 newPosition = this.gameObject.transform.position;
        newPosition.y = Random.Range(-3, 3);

        this.gameObject.transform.position = newPosition;

        // randomly decide which power up this is -- 3 choices, our paddle larger, opponent paddle smaller, opponent freeze
        powerUpType = Random.Range(1, 4);

        if (powerUpType == 1)
            _renderer.material.SetColor("_Color", Color.red);
        else if (powerUpType == 2)
            _renderer.material.SetColor("_Color", Color.blue);
        else if (powerUpType == 3)
            _renderer.material.SetColor("_Color", Color.green);
        else
            _renderer.material.SetColor("_Color", Color.white);

        this.gameObject.SetActive(true);
        Invoke("Hide", stayTime); // power up stays up for this many seconds
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
        Invoke("Show", Random.Range(randomMin, randomMax));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball.GetHitLast() == 1)
        {
            // apply powerup for player 1 against player 2
            if (powerUpType == 1)
            {
                player2Paddle.Shrink();
            }
            else if (powerUpType == 2)
            {
                player2Paddle.Freeze();
            }
            else if (powerUpType == 3)
            {
                player1Paddle.Expand();
            }
        }
        else if (ball.GetHitLast() == 2)
        {
            // apply powerup for player 1 against player 2
            if (powerUpType == 1)
            {
                player1Paddle.Shrink();
            }
            else if (powerUpType == 2)
            {
                player1Paddle.Freeze();
            }
            else if (powerUpType == 3)
            {
                player2Paddle.Expand();
            }
        }


    }

}
