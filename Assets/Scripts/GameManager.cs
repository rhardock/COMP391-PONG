using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI player1WinsText;
    public TextMeshProUGUI player2WinsText;
    public Paddle player1Paddle;
    public Paddle player2Paddle;
    public int winScore = 3;

    private int _player1Score = 0;
    private int _player2Score = 0;

    private int _player1Wins = 0;
    private int _player2Wins = 0;

    public void Player1Scores()
    {
        _player1Score++;

        this.player1ScoreText.text = _player1Score.ToString();

        if (_player1Score >= winScore)
        {
            _player1Wins++;
            ResetGame();
        }
        else
            ResetRound();
    }

    public void Player2Scores()
    {
        _player2Score++;

        this.player2ScoreText.text = _player2Score.ToString();
        

        if (_player2Score >= winScore)
        {
            _player2Wins++;
            ResetGame();
        }
        else
            ResetRound();
    }

    private void ResetRound()
    {
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
        this.ball.SetHitLast(0);
    }

    private void ResetGame()
    {
        _player1Score = 0;
        _player2Score = 0;
        this.player1ScoreText.text = _player1Score.ToString();
        this.player2ScoreText.text = _player2Score.ToString();

        this.player1WinsText.text = _player1Wins.ToString();
        this.player2WinsText.text = _player2Wins.ToString();

        ResetRound();
    }
}
